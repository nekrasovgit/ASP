using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingService.BookingService;
using BookingService.HeaderService;
using BookingService.MapperProfile;
using BookingService.Model;
using BookingService.Publisher;
using BookingService.Quartz.Job;
using BookingService.Quartz.JobFactory;
using BookingService.Quartz.QuartzHostedService;
using BookingService.Quartz.Scheduler;
using EasyNetQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace BookingService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionRabbitMQ = Configuration.GetConnectionString("Config");
            services.AddSingleton(RabbitHutch.CreateBus(connectionRabbitMQ).Advanced);
            services.Configure<ReservationSettings>(Configuration.GetSection(nameof(ReservationSettings)));
            services.AddSingleton<IReservationSettings>(sp => sp.GetRequiredService<IOptions<ReservationSettings>>().Value);
            services.AddScoped<IPublisher, Publisher.Publisher>();
            services.AddScoped<IHeaderService, HeaderService.HeaderService>();
            services.AddScoped<IBookingService, BookingService.BookingService>();
            services.AddSingleton<IJobFactory, JobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<Job>();
            services.AddSingleton<JobRunner>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(Job),
                cronExpression: "* 1 * * * ?"));
            services.AddHostedService<QuartzHostedService>();

            services.AddHttpContextAccessor();
            services.AddMapper();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
