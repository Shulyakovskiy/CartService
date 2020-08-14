using Domain.Cart.Entity;
using Newtonsoft.Json;

namespace Domain.Cart.Dto
{
    /// <summary>
    /// Список корзин с продуктами
    /// </summary>
    public class CartReadDto
    {
        /// <summary>
        /// Корзина
        /// </summary>
        [JsonProperty("id")]
        public int CartId { get; set; }

        /// <summary>
        /// Ввладелец
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        [JsonProperty("products")]
        public Product Products { get; set; }
    }
}