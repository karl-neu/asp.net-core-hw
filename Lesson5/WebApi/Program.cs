using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.CustomLogging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .ConfigureLogging((hostBuilderContext, logging) =>
                {
                    logging.ClearProviders();

                    var options = hostBuilderContext.Configuration.GetSection("ColorOptions").Get<CustomConsoleLoggerOptions>();

                    logging.AddProvider(new CustomLoggerProvider(options));

                }).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}