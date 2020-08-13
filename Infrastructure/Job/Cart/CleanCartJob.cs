using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Scheduler;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Persistence.Repository.Cart.Services;

namespace Infrastructure.Job.Cart
{
    /// <summary>
    /// Очистка корзин
    /// </summary>
    [UsedImplicitly]
    public class CleanCartJob : CronJobService
    {
        private readonly IJobCartService _jobCartService;
        private readonly ILogger<CleanCartJob> _logger;

        public CleanCartJob(IScheduleConfig<CleanCartJob> config, IJobCartService jobCartService, ILogger<CleanCartJob> logger) 
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _jobCartService = jobCartService;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _jobCartService.JobCleanCart();
            _logger.LogInformation("CleanCartJob 3 starts.");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} CleanCartJob 3 is working.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CleanCartJob 3 is stopping.");
            return base.StopAsync(cancellationToken);
        }

    }
}