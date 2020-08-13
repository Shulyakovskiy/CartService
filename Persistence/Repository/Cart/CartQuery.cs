using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Domain.Cart.Dto;
using Domain.Cart.Entity;
using Persistence.Core.Services;

namespace Persistence.Repository.Cart
{
    public class CartQuery : ICartService
    {
        private readonly IRepository _repository;

        public CartQuery(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Список корзин с продуктами
        /// </summary>
        public async Task<IEnumerable<CartDto>> ProductGet()
        {
            return await _repository.GetConnection(c =>
                 c.QueryAsync<CartDto>(@"dbo.Cart_Get", commandType: CommandType.StoredProcedure));
        }
    }
}