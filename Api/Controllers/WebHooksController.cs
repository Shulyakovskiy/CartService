using System.Collections.Generic;
using System.Threading.Tasks;
using Application.WebHooks.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    /// <summary>
    /// Перехватчик событий (trigger)
    /// </summary>
    public class WebHookController : BaseController
    {
        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult<Unit>> Register([FromBody] RegisterHooks.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
