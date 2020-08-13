using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Domain.Cart.Entity;
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

        /// <summary>
        /// Построение отчета
        /// </summary>
        public void CreateReportData()
        {
            _repository.GetConnection(c => c.Execute(@"Report.JobCartInfo_Ins", commandType: CommandType.StoredProcedure));
        }

        /// <summary>
        /// Средний чек по корзинам
        /// </summary>
        public IEnumerable<CartInfo> CartAvgCheckGet()
        {
            return _repository.GetConnection(c => c.Query<CartInfo>(@"Report.CartAvgCheck_Get", commandType: CommandType.StoredProcedure));
        }

        /// <summary>
        /// Информация по корзинам
        /// </summary>
        public CartInfo CartInfoGet()
        {
            return _repository.GetConnection(c => c.Query<CartInfo>(@"Report.CartInfo_Get", commandType: CommandType.StoredProcedure))
                .FirstOrDefault();
        }
    }
}