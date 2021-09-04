using Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Validation;

namespace WebApi.DTO
{
    [ProductValidation]
    public class dtoProduct : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [isStartsWithCapital]
        public string Title { get; set; }
        public double Price { get; set; }

        public int? WarehouseId { get; set; }

        public void Map(Product product)
        {
            product.Id = Id;
            product.Title = Title;
            product.Price = Price;
            product.WarehouseId = WarehouseId;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.Title.Length < 3)
                errors.Add(new ValidationResult("Title length must be longer"));

            if (this.Price > 999)
                errors.Add(new ValidationResult("Price must be cheaper"));

            return errors;
        }
    }
}