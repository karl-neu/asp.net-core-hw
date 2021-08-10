using Microsoft.Extensions.Configuration;
using System;
using WebApp.Providers;

namespace WebApp.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCustomConfiguration(
            this IConfigurationBuilder builder, string path)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Path is empty");

            var source = new CustomConfigurationSource(path);

            return builder.Add(source);
        }
    }
}
