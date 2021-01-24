using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using Scheduler.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scheduler.Quartz.CancelReservationJob
{
    [DisallowConcurrentExecution]
    public class RemoveReservationJob : IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<RemoveReservationJob> _logger;
        private readonly IServiceProvider _pr;
        private readonly IPublisher _publisher;


        public RemoveReservationJob(IServiceScopeFactory serviceScopeFactory, ILogger<RemoveReservationJob> logger, IServiceProvider pr,
            IPublisher publisher)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
            _pr = pr;
            _publisher = publisher;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("__________Let's delete_______________");

            var mesage = new DeleteMessage() { Message = "Let's delete" };

            await _publisher.PublishDeleteMessage(mesage);

        }
    }
}
