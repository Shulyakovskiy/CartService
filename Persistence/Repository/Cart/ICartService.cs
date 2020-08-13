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
        Task<IEnumerable<CartDto>> ProductGet();
    }
}