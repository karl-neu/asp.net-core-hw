using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Models
{
    public class ProductInfo
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}