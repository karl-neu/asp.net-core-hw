using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Models
{
    class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted(); 
            Database.EnsureCreated();
        }
    }
}