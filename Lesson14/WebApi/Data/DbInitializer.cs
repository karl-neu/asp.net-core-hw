using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApi.Data.Entities;

namespace WebApi.Data
{
    public class DbInitializer
    {
        public static async Task UserRoleInizializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@mail.com";
            string password = "Aa1234!";            //password for admin and viewer is same

            string viewerEmail = "viewer@mail.com";


            if (await roleManager.FindByNameAsync("admin") == null)
                await roleManager.CreateAsync(new IdentityRole("admin"));

            if (await roleManager.FindByNameAsync("viewer") == null)
                await roleManager.CreateAsync(new IdentityRole("viewer"));

            if (await userManager.FindByNameAsync(viewerEmail) == null)
            {
                var viewer = new ApplicationUser { Email = viewerEmail, UserName = viewerEmail, Description = "123" };
                IdentityResult result = await userManager.CreateAsync(viewer, password);

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(viewer, "viewer");
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail, Description = "12345" };
                IdentityResult result = await userManager.CreateAsync(admin, password);

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}