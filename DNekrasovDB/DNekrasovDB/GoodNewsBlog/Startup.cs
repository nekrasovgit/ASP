using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using GoodNewsBlog.Hangfire;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GoodNewsBlog
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
            // подключить контекст данных
            string connection = Configuration.GetConnectionString("DefaultConnection");
            /*services.AddDbContext<GoodNewsContext>(options => options.UseSqlServer(connection));*/


            services.AddAutoMapper(typeof(Startup));

            services.AddHangfire(config => config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseDefaultTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connection, new SqlServerStorageOptions()
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));

            services.AddHangfireServer();


            services.AddSingleton<IJobs, Jobs>();

            services.AddCors();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            //services.AddScoped<IUserService, UserService>();

            services.AddSwaggerGen(sa =>
            {
                sa.SwaggerDoc("v1", new OpenApiInfo() { Title = "Jwt Token Sample API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                sa.IncludeXmlComments(xmlPath);
            });

            /*services.AddIdentity<JwtAppUser, IdentityRole>(opt => opt
            .SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStore<goodNewsContext>();*/

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager,
            IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(sa => 
            {
                sa.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            /*app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            
            app.UseMiddleware<JwtMiddleware>();*/


            app.UseHangfireDashboard();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });

            
            recurringJobManager.AddOrUpdate(
                "Run every hour",
                () => serviceProvider.GetService<IJobs>().Print(),
                "* * * * *");
        }
    }
}
