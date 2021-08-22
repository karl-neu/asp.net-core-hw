using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp.Models
{
    class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
    {
        public CatalogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            var configurationRoot = configurationBuilder.Build();
            var connectionString = configurationRoot.GetConnectionString("Lesson9DbConnectionStr");

            var contextOptions = new DbContextOptionsBuilder<CatalogDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            optionsBuilder.UseSqlServer(connectionString);

            return new CatalogDbContext(contextOptions);
        }
    }
}