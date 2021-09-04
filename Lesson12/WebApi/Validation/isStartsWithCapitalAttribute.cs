using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class isStartsWithCapitalAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string title = value.ToString();

                if (Char.IsUpper(title[0]))         //check if first character is uppercase
                    return true;
                else
                    this.ErrorMessage = GetErrorMessage();
            }

            return false;
        }

        public string GetErrorMessage() =>
        $"String must starts with capital.";
    }
}