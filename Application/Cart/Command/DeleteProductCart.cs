using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using Newtonsoft.Json;
using Persistence.Repository.Cart;

namespace Application.Cart.Command
{
    [UsedImplicitly]
    public class DeleteProductCart
    {
        public class Command : IRequest
        {
            [JsonProperty("cartId")]
            public int CartId { get; set; }

            [JsonProperty("products")]
            public List<int> Products { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ICartService _cartService;

            public Handler(ICartService cartService)
            {
                _cartService = cartService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var cartId = request.CartId;
                var productIds = request.Products;
                await _cartService.DeleteCartItem(cartId, productIds);
                return Unit.Value;
            }
        }
    }
}