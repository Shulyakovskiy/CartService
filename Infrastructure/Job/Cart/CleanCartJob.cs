using System.Threading.Tasks;
using Persistence.Repository.Cart.Services;
using Quartz;

namespace Infrastructure.Job.Cart
{
    /// <summary>
    /// Очистка корзин
    /// </summary>
    public class CleanCartJob : IJob
    {
        private readonly IJobCartService _jobCartService;

        public CleanCartJob(IJobCartService jobCartService)
        {
            _jobCartService = jobCartService;

        }

        public Task Execute(IJobExecutionContext context)
        {
            _jobCartService.JobCleanCart();
            return Task.CompletedTask;
        }
    }
}