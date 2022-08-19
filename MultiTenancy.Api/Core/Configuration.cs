namespace MultiTenancy.Api.Core
{
    public static class Configuration
    {
        public static string ApplicationRoot => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string EnvironmentName
        {
            get
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (environment == null || environment == "Local")
                {
                    environment = "Development";
                }

                return environment;
            }
        }

        public static bool IsLocal => EnvironmentName == "Local" || EnvironmentName == "Development";

        public static T GetConfiguration<T>()
        {
            var config = new ConfigurationBuilder()
                              .SetBasePath(AppContext.BaseDirectory)
                              .AddJsonFile($"appsettings.{EnvironmentName}.json").Build()
                              .Get<T>();

            var allProperties = config.GetType().GetProperties();

            foreach (var property in allProperties)
            {
                var value = property.GetValue(config);
                if (value == null)
                {
                    throw new ConfigurationException($"Property {property.Name} is missing from the configuration file.");
                }
            }

            return config;
        }
    }

    public class ConfigurationException : Exception
    {
        public ConfigurationException() { }
        public ConfigurationException(string message) : base(message) { }
    }
}
