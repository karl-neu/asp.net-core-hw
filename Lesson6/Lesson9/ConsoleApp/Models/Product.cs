using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public ProductInfo ProductInfo { get; set; }

        public int? ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public List<Warehouse> Warehouses { get; set; }
    }
}