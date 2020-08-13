using Microsoft.Extensions.Configuration;
using System.IO;
using JetBrains.Annotations;

namespace Common.Settings
{
    /// <summary>
    /// Settings
    /// </summary>
    [UsedImplicitly]
    public class AppConfiguration
    {
        /// <summary>
        /// build configuration file
        /// </summary>
        /// <returns>IConfigurationRoot</returns>
        public static IConfigurationRoot OnConfiguring()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config;
        }
    }
}