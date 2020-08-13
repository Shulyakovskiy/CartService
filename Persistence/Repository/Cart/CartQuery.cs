using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Common.Dal;
using Dapper;
using Persistence.Core.Services;

namespace Persistence.Repository.Cart
{
    /// <summary>
    /// Репозиторий товаров и корзин
    /// </summary>
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
        public async Task<IEnumerable<Domain.Cart.Entity.Cart>> ProductGet()
        {
            return await Task.Run(() => _repository.GetConnection(c =>
                 c.Query<Domain.Cart.Entity.Cart>(@"dbo.Cart_Get", commandType: CommandType.StoredProcedure)));
        }

        /// <summary>
        /// Удаление продуктов из корзины
        /// </summary>
        public async Task DeleteCartItem(int @cartId, List<int> @productIds)
        {
            await Task.Run(() => _repository.GetConnection(c =>
               c.Query<Domain.Cart.Entity.Cart>(@"dbo.DelCartItem_Upd", new { @cartId, productIds = @productIds.AsTableValuedParameter("dbo.ValInt") },
            commandType: CommandType.StoredProcedure)));
        }
    }
}