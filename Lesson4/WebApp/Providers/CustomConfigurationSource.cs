using Microsoft.Extensions.Configuration;

namespace WebApp.Providers
{
    public class CustomConfigurationSource : IConfigurationSource
    {
        private readonly string _path;

        public CustomConfigurationSource(string path) =>
            _path = path;

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new CustomConfigurationProvider(_path);
    }
}