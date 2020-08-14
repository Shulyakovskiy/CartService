using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Common.Dal;
using Dapper;
using Persistence.Core.Services;
using Persistence.Repository.Cart.Services;

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
        public async Task DeleteCartItem(int @cartId, int @userId, List<int> @productIds)
        {
            await Task.Run(() => _repository.GetConnection(c =>
               c.Execute(@"dbo.DelCartItem_Upd", new { @cartId, @userId, productIds = @productIds.AsTableValuedParameter("dbo.ValInt") },
            commandType: CommandType.StoredProcedure)));
        }


        /// <summary>
        /// Добавление продуктов в корзину
        /// </summary>
        public async Task AddCartItem(int cartId, List<int> productIds)
        {
            await Task.Run(() => _repository.GetConnection(c =>
                c.Execute(@"dbo.AddCartItem_Upd", new { @cartId, productIds = @productIds.AsTableValuedParameter("dbo.ValInt") },
                    commandType: CommandType.StoredProcedure)));
        }
    }
}