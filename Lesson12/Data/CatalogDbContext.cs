using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options) { }
    }
}
