using System.Collections.Generic;
using Domain.Cart.Entity;

namespace Domain.Cart.Dto
{
    /// <summary>
    /// Список корзин с продуктами
    /// </summary>
    public class CartDto
    {
        /// <summary>
        /// Корзина
        /// </summary>
        public Entity.Cart Cart { get; set; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        public IList<Product> Products { get; set; }
    }
}