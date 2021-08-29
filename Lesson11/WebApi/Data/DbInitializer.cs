using System.Linq;
using WebApi.Models;

namespace WebApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CatalogDbContext context)
        {
            if (context.Products.Any()) return;

            var warehouse1 = new Warehouse
            {
                Title = "W #1",
                Address = "Vul. Shevchenka 27"
            };
            var warehouse2 = new Warehouse
            {
                Title = "W #2",
                Address = "Vul. Gonchara 9"
            };

            context.Warehouses.AddRange(warehouse1, warehouse2);
            context.SaveChanges();

            var products = new Product[] {
                new Product {
                    Title = "Potato",
                    Price = 1.5,
                    Warehouse = warehouse1
                },
                new Product {
                    Title = "Tomato",
                    Price = 2.7,
                    Warehouse = warehouse1
                },
                new Product {
                    Title = "Apple",
                    Price = 4.3,
                    Warehouse = warehouse2
                }};

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}