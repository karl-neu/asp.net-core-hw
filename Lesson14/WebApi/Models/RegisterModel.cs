using System.ComponentModel.DataAnnotations;
using WebApi.Data.Entities;

namespace WebApi.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(150,
            MinimumLength = 3,
            ErrorMessage = "Description length must be between 3 and 150")]
        public string Description { get; set; }

        public void Map(ApplicationUser user)
        {
            user.Email = Email;
            user.UserName = Email;
            user.Description = Description;
        }
    }
}