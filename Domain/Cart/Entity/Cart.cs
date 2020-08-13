namespace Domain.Cart.Entity
{
    public class Cart
    {
        public int CartId { get; set; }

        /// <summary>
        /// Identity
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Бонусы
        /// </summary>
        public bool ForBonusPoints { get; set; }
    }
}