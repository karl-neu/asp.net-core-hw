using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Configuration
{
    public class AuthOptions
    {
        public const string Issuer = "AuthServer";
        public const string Audience = "IdentityClient";
        public const string Key = "Custom Secret_key 1234!";
        public const int LifeTime = 25;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
