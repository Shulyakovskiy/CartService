using Newtonsoft.Json;

namespace Domain.WebHooks.Dto
{
    public class UserWebHookDto
    {
        /// <summary>
        /// Пользователь кому принадлежит событие
        /// </summary>
        [JsonProperty("userId")]
        public int UserId { get; set; }

        /// <summary>
        /// Имя события
        /// </summary>
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        /// <summary>
        /// Конечная точка обработчик
        /// </summary>
        [JsonProperty("endpointRequest")]
        public string EndpointRequest { get; set; }

        /// <summary>
        /// POST данные
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}