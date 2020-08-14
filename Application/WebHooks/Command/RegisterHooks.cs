using System.Threading;
using System.Threading.Tasks;
using Domain.WebHooks.Entity;
using JetBrains.Annotations;
using MediatR;
using Newtonsoft.Json;
using Persistence.Repository.WebHooks.Services;

namespace Application.WebHooks.Command
{
    [UsedImplicitly]
    public class RegisterHooks
    {
        public class Command : IRequest
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

        public class Handler : IRequestHandler<RegisterHooks.Command>
        {
            private readonly IWebHookService _webHookService;

            public Handler(IWebHookService webHookService)
            {
                _webHookService = webHookService;
            }

            /// <summary>
            /// Добавление произвольного числа продуктов
            /// </summary>
            public async Task<Unit> Handle(RegisterHooks.Command request, CancellationToken cancellationToken)
            {
                var hook = new UserWebHook
                {
                    UserId = request.UserId,
                    EndpointRequest = request.EndpointRequest,
                    EventName = request.EventName,
                    Payload = request.Payload
                };

                await _webHookService.RegisterHooks(hook);
                return Unit.Value;
            }
        }
    }
}