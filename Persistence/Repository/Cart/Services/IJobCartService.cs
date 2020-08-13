using System.Threading.Tasks;

namespace Persistence.Repository.Cart.Services
{
    public interface IJobCartService
    {
        /// <summary>
        /// Удаление корзин по истечении времени
        /// </summary>
        void JobCleanCart();
    }
}