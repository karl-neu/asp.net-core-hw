using Microsoft.AspNetCore.Identity;

namespace WebApi.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Description { get; set; }
    }
}