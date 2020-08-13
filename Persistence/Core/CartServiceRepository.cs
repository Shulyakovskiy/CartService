using System;
using System.Data;
using System.Data.SqlClient;
using Common.Settings;
using JetBrains.Annotations;
using Persistence.Core.Services;

namespace Persistence.Core
{
    /// <summary>
    /// Repository CartService
    /// </summary>
    public class CartServiceRepository : Repository, IRepository
    {
        
        /// <summary>
        /// Database String Connection
        /// </summary>
        [CanBeNull]
        private readonly string _connectionString = AppConfiguration.OnConfiguring()["CartServiceConnection"];

        /// <summary>
        /// Return Sql Server Connection
        /// </summary>
        /// <param name="getData">Return DB connection</param>
        /// <returns>T</returns> 
        public  T GetConnection<T>(Func<IDbConnection, T> getData)
        {
            using var sqlConnection = new SqlConnection(_connectionString);
            var connection = ExecuteWithHandleDeadlock(() => getData(arg: sqlConnection));
            sqlConnection.Open();
            return connection;
        }
    }
}