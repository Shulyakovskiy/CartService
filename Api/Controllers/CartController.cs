using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Cart.Query;
using Domain.Cart.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CartController : BaseController
    {

        [Route("List")]
        [HttpGet]
        public async Task<ActionResult<List<CartDto>>> List(CancellationToken ct)
        {
            return await Mediator.Send(new ListCart.Query(), ct);
        }
    }
}
