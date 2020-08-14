namespace Domain.Cart.Entity
{
    public class User
    {
        /// <summary>
        /// Идентфикатор
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }
    }
}