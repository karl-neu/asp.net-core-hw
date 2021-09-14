using Microsoft.AspNetCore.Authorization;

namespace WebApi.Requirements
{
    public class CustomRequirement : IAuthorizationRequirement
    {
        public int Descripion { get; private set; }

        public CustomRequirement(int descripionMinimumLength)
        {
            Descripion = descripionMinimumLength;
        }
    }
}