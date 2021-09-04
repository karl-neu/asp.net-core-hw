using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public double Price { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
