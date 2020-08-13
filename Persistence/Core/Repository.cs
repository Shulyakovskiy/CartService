using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Persistence.Core
{
    /// <summary>
    /// Base Repository
    /// </summary>
    public class Repository 
    {

        /// <summary>
        /// Deadlock Monitor
        /// </summary>
        protected virtual T ExecuteWithHandleDeadlock<T>(Func<T> func, string database = "Unknown", int systemId = 0, string assemblyName = "Unknown")
        {
            int tryCount = 5;
            do
            {
                try
                {
                    return func();
                }
                catch (SqlException)
                {
                    if (--tryCount < 0)
                        throw;
                    Task.Delay(500).Wait();
                }
            } while (true);
        }
    }
}