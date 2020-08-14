using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.WebHooks.Entity;

namespace Persistence.Repository.WebHooks.Services
{
    /// <summary>
    /// Перехватчики событий
    /// </summary>
    public interface IWebHookService
    {
        /// <summary>
        /// Регистрация обработчика
        /// </summary>
        Task RegisterHooks(UserWebHook userWebHook);
    }
}