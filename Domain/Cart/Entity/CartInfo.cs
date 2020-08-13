namespace Domain.Cart.Entity
{
    public class CartInfo
    {
        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public int CartId  { get; set; }

        /// <summary>
        /// Средний чек по корзине
        /// </summary>
        public decimal CartAvgCheck { get; set; }

        /// <summary>
        /// Всего карт
        /// </summary>
        public int TotalCart { get; set; }

        /// <summary>
        /// Карт с бонусами
        /// </summary>
        public int CartProductOfBonus { get; set; }

        /// <summary>
        /// Протухают через 10 дней
        /// </summary>
        public int CartExpire10Day { get; set; }

        /// <summary>
        /// Протухают через 20 дней
        /// </summary>
        public int CartExpire20Day { get; set; }

        /// <summary>
        /// Протухают через 30 дней
        /// </summary>
        public int CartExpire30Day { get; set; }
    }
}