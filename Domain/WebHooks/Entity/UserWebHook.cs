namespace Domain.WebHooks.Entity
{
    /// <summary>
    /// Обработчик событий
    /// </summary>
    public class UserWebHook
    {
        /// <summary>
        /// Идентификатор события
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя события
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Конечная точка обработчик
        /// </summary>
        public string EndpointRequest { get; set; }

        /// <summary>
        /// POST данные
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Пользователь кому принадлежит событие
        /// </summary>
        public int UserId { get; set; }
    }
}