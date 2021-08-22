using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

/*Домашнє завдання:
З використанням EntityFramework Core cтворити модель в якій будуть реалізовані всі типи звязку 
(один-до-одного, один-до-багатьох, багато-до-багатьох)
Створити міграції і згенерувати базу даних
Створити запити до бази даних (читання, додавання, оновлення, видалення).
Приклади оновлення і видалення я додам в код також.*/
namespace ConsoleApp
{
    class Program
    {
        //Программу нужно два раза запустить,
        //при первом запуске она создает бд и заполняет ее данными,
        //при втором уже выполняет остальные CRUD операции.

        static CatalogDbContext Context;

        static void Main(string[] args)
        {
            using (Context = new CatalogDbContext(GetOptions()))
            {
                if (!Context.Products.AnyAsync().Result) SeedDb();        //add

                try
                {
                    ShowProducts(Context.Products.ToListAsync().Result);        //read
                }
                catch (System.Exception)
                {
                    System.Console.WriteLine("Database generated and seeded. Please Re-run Program");
                    return;
                }

                var potato = Context.Products.FirstOrDefaultAsync(p => p.Title == "Potato").Result;         //update
                if (potato != null)
                {
                    potato.Title = "Egypt Potato";

                    Context.Products.Update(potato);
                    Context.SaveChanges();
                }

                var tomato = Context.Products.Include(x => x.ProductInfo)
                    .FirstOrDefaultAsync(p => p.Title == "Tomato").Result;         //delete Product with ProductInfo
                if (tomato != null)
                {
                    Context.Products.Remove(tomato);
                    Context.SaveChanges();
                }
            }
        }

        static void ShowProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                System.Console.WriteLine($"{product.Id} {product.Title}");
            }
        }

        static void SeedDb()
        {
            using (Context = new CatalogDbContext(GetOptions()))        // GetOptions() - method with config db
            {
                var product1 = AddProduct(new Product { Title = "Potato" });
                var product2 = AddProduct(new Product { Title = "Tomato" });
                Context.SaveChanges();

                AddProductInfo(new ProductInfo
                {
                    SerialNumber = $"{product1.Title} #{product1.Id}",
                    ProductId = product1.Id
                });
                AddProductInfo(new ProductInfo
                {
                    SerialNumber = $"{product2.Title} #{product2.Id}",
                    ProductId = product2.Id
                });
                Context.SaveChanges();

                var manufacturer1 = AddManufacturer(new Manufacturer
                {
                    Title = "Agro21",
                    Address = "Vul. Shevchenka 27",
                    Products = new List<Product>() { product1 }
                });
                var manufacturer2 = AddManufacturer(new Manufacturer
                {
                    Title = "AgroDruzi",
                    Address = "Vul. Sikorskogo 17",
                    Products = new List<Product>() { product2 }
                });
                Context.SaveChanges();

                var warehouse1 = AddWarehouse(new Warehouse
                {
                    Title = "Sklad #1",
                    Address = "Vul. Sahaidachnogo 40",
                    Products = new List<Product>() { product1, product2 }
                });

                var warehouse2 = AddWarehouse(new Warehouse
                {
                    Title = "Sklad #2",
                    Address = "Vul. Lesi Ukrainky 15",
                    Products = new List<Product>() { product1 }
                });

                Context.SaveChanges();
            }
        }

        static DbContextOptions<CatalogDbContext> GetOptions() //config
        {
            var configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configurationBuilder.AddJsonFile("appsettings.json");

            var configurationRoot = configurationBuilder.Build();
            var connectionString = configurationRoot.GetConnectionString("Lesson9DbConnectionStr");

            return new DbContextOptionsBuilder<CatalogDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        static Product AddProduct(Product product)
        {
            return Context.Products.Add(product).Entity;
        }

        static ProductInfo AddProductInfo(ProductInfo productInfo)
        {
            return Context.ProductInfos.Add(productInfo).Entity;
        }

        static Manufacturer AddManufacturer(Manufacturer manufacturer)
        {
            return Context.Manufacturers.Add(manufacturer).Entity;
        }

        static Warehouse AddWarehouse(Warehouse warehouse)
        {
            return Context.Warehouses.Add(warehouse).Entity;
        }
    }
}