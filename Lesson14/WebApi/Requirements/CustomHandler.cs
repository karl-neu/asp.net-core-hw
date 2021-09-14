using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Requirements
{
    public class CustomHandler : AuthorizationHandler<CustomRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == OwnClaims.Description))
            {
                var description = context.User.FindFirstValue(OwnClaims.Description);

                if (description.Length >= requirement.Descripion)
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}