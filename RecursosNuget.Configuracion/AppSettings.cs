using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RecursosNuget.Configuracion {
    public class AppSettings {
        #pragma warning disable CS8602

        private readonly IConfiguration iConfiguration;
        private readonly ServiceCollection serviceCollection;
        
        public AppSettings(string? fileName = null, string? path = null) {
            serviceCollection = new ServiceCollection();
            iConfiguration = createIConfiguration(fileName, path);
            serviceCollection.AddSingleton<IConfiguration>(iConfiguration);
        }

        #region [ Public Methods ]
        public IConfigurationSection GetConfigurationSection(string key) => iConfiguration.GetSection(key);
        public string? GetConfigurationSectionValue(string key) => GetConfigurationSection(key).Value;
        public string? GetConnectionString(string key) => iConfiguration.GetConnectionString(key);
        #endregion

        #region [ Static Methods ]
        public static IConfigurationSection GetConfigurationSection(string key, string? fileName = null, string? path = null) {
            var sCollection = new ServiceCollection();
            var iConfiguration = createIConfiguration(fileName, path);
            sCollection.AddSingleton<IConfiguration>(iConfiguration);
            
            return iConfiguration.GetSection(key);
        }
        public static string? GetConfigurationSectionValue(string key, string? fileName = null, string? path = null) {
            var sCollection = new ServiceCollection();
            var iConfiguration = createIConfiguration(fileName, path);
            sCollection.AddSingleton<IConfiguration>(iConfiguration);
            
            return iConfiguration.GetSection(key).Value;
        }
        public static string? GetConnectionString(string key, string? fileName = null, string? path = null) {
            var sCollection = new ServiceCollection();
            var iConfiguration = createIConfiguration(fileName, path);
            sCollection.AddSingleton<IConfiguration>(iConfiguration);
            
            return iConfiguration.GetConnectionString(key);
        }
        #endregion

        #region [ Private Methods ] 
        private static IConfiguration createIConfiguration(string? fileName = null, string? path = null) {
            return new ConfigurationBuilder()
                .SetBasePath(path ?? (Directory.GetParent(AppContext.BaseDirectory).FullName))
                .AddJsonFile(fileName ?? "appsettings.json").Build();
        }
        #endregion
    }
}
