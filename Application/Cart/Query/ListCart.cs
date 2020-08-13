using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Cart.Dto;
using JetBrains.Annotations;
using MediatR;
using Persistence.Repository.Cart;

namespace Application.Cart.Query
{
    [UsedImplicitly]
    public class ListCart
    {
        public class Query : IRequest<List<CartDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<CartDto>>
        {
            private readonly ICartService _cartService;

            public Handler(ICartService cartService)
            {
                _cartService = cartService;
            }

            public async Task<List<CartDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cartList = await _cartService.ProductGet();
                return (List<CartDto>)cartList;
            }
        }
    }
}