using System;
using System.Data;
using JetBrains.Annotations;

namespace Persistence.Core.Services
{
    /// <summary>
    /// Contract Repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Return Sql Server Connection and include param Query
        /// </summary>
        /// 
        /// <returns>SqlConnection</returns>
        [UsedImplicitly]
        T GetConnection<T>(Func<IDbConnection, T> getData);
    }
}