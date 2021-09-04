using System;
using System.ComponentModel.DataAnnotations;
using WebApi.DTO;

namespace WebApi.Validation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProductValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var dtoProduct = (dtoProduct)value;

                if (dtoProduct.Price > 0)
                    return true;
                else
                    this.ErrorMessage = GetErrorMessage();
            }

            return false;
        }

        public string GetErrorMessage() =>
            $"Price must be greater then zero";
    }
}
