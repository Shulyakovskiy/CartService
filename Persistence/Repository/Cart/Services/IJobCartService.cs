using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Cart.Entity;

namespace Persistence.Repository.Cart.Services
{
    public interface IJobCartService
    {
        /// <summary>
        /// Удаление корзин по истечении времени
        /// </summary>
        void JobCleanCart();

        /// <summary>
        /// Построение отчета
        /// </summary>
        void CreateReportData();

        /// <summary>
        /// Средний чек по корзинам
        /// </summary>
        IEnumerable<CartInfo> CartAvgCheckGet();

        /// <summary>
        /// Информация по корзинам
        /// </summary>
        CartInfo CartInfoGet();
    }
}