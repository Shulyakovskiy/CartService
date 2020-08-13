using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Cart.Dto;

namespace Persistence.Repository.Cart
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
        Task DeleteCartItem(int @cartId, List<int> @productIds);

        /// <summary>
        /// Добавление продуктов в корзину
        /// </summary>
        Task AddCartItem(int @cartId, List<int> @productIds);
    }
}