using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository.Cart.Services
{
    public interface ICartService
    {
        /// <summary>
        /// Список корзин с продуктами
        /// </summary>
        Task<IEnumerable<Domain.Cart.Entity.Cart>> ProductGet();

        /// <summary>
        /// Удаление продуктов из корзины
        /// </summary>
        Task DeleteCartItem(int @cartId, int @userId, List<int> @productIds);

        /// <summary>
        /// Добавление продуктов в корзину
        /// </summary>
        Task AddCartItem(int @cartId, List<int> @productIds);
    }
}