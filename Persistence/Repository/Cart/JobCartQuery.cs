using System.Data;
using System.Threading.Tasks;
using Dapper;
using Persistence.Core.Services;
using Persistence.Repository.Cart.Services;

namespace Persistence.Repository.Cart
{
    public class JobCartQuery : IJobCartService
    {
        private readonly IRepository _repository;

        public JobCartQuery(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Удаление корзин по истечении времени
        /// </summary>
        public void JobCleanCart()
        {
            _repository.GetConnection(c =>
                   c.Execute(@"dbo.JobCleanCart_Del", commandType: CommandType.StoredProcedure));
        }
    }
}