using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Cart.Command;
using Application.Cart.Query;
using Domain.Cart.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CartController : BaseController
    {

        [Route("ListCart")]
        [HttpGet]
        public async Task<ActionResult<List<CartReadDto>>> ListCart(CancellationToken ct)
        {
            return await Mediator.Send(new ListCart.Query(), ct);
        }

        [Route("DeleteItemsCart")]
        [HttpPut]
        public async Task<ActionResult<Unit>> DeleteItemsCart(DeleteProductCart.Command command)
        {
            return await Mediator.Send(command);
        }

        [Route("AddItemsCart")]
        [HttpPost]
        public async Task<ActionResult<Unit>> AddItemsCart(DeleteProductCart.Command command)
        {
            return await Mediator.Send(command);
        }
    }
}
