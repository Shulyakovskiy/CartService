using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Cart.Dto;
using Domain.Cart.Entity;
using JetBrains.Annotations;
using MediatR;
using Persistence.Repository.Cart;

namespace Application.Cart.Query
{
    [UsedImplicitly]
    public class ListCart
    {
        public class Query : IRequest<List<CartReadDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<CartReadDto>>
        {
            private readonly ICartService _cartService;

            public Handler(ICartService cartService)
            {
                _cartService = cartService;
            }

            /// <summary>
            /// Список корзин с продуктами
            /// </summary>
            public async Task<List<CartReadDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cartList = await _cartService.ProductGet();
                var resultTo = cartList.Select(c => new CartReadDto
                {
                    CartId = c.CartId,
                    Products =
                        new Product
                        {
                            Id = c.CartId,
                            Cost = c.Cost,
                            ForBonusPoints = c.ForBonusPoints,
                            Name = c.Name
                        }
                });
                return resultTo.ToList();
            }
        }
    }
}