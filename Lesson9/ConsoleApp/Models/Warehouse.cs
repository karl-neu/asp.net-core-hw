using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class Warehouse
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Address { get; set; }

        public List<Product> Products { get; set; }
    }
}