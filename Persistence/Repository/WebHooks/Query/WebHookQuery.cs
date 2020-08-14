using System.Data;
using System.Threading.Tasks;
using Dapper;
using Domain.WebHooks.Entity;
using Persistence.Core.Services;
using Persistence.Repository.WebHooks.Services;

namespace Persistence.Repository.WebHooks.Query
{
    public class WebHookQuery : IWebHookService
    {
        private readonly IRepository _repository;

        public WebHookQuery(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Регистрация обработчика
        /// </summary>
        public async Task RegisterHooks(UserWebHook @userWebHook)
        {
            await Task.Run(() => _repository.GetConnection(c =>
                c.Execute(@"Hooks.RegisterHooks_Ins", new
                {
                    @userWebHook.UserId ,
                    @userWebHook.EndpointRequest,
                    @userWebHook.Payload,
                    @userWebHook.EventName

                }, commandType: CommandType.StoredProcedure)));
        }
    }
}