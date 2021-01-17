using BookingService.BookingService;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Quartz.Job
{
    [DisallowConcurrentExecution]
    public class Job : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public Job(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var sheckReservation = scope.ServiceProvider.GetService<IBookingService>();

                await sheckReservation.CheckReservation();
            };
        }
    }
}
