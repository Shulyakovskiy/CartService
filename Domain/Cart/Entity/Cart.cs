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
        /// Пользователь
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

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