using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Configuration;
using WebApi.Data.Entities;
using WebApi.Models;
using WebApi.Requirements;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // https://localhost:5001/Account/Register

        /*{
            "email": "mail@mail.com",
            "password": "Aa12345!",
            "description": "description"
          }*/

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var user = new ApplicationUser();
            registerModel.Map(user);

            var identityResult = await _userManager.CreateAsync(user, registerModel.Password);

            if (identityResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "viewer");      //registered like a viewer
                //await _signInManager.SignInAsync(user, false);
                return Ok();
            }

            foreach (var identityError in identityResult.Errors)
                ModelState.AddModelError("Register", identityError.Description);

            return BadRequest();
        }

        // https://localhost:5001/Account/Login

        //admin role
        /*{
            "email": "admin@mail.com",
            "password": "Aa1234!"
          }*/

        //viewer role
        /*{
           "email": "viewer@mail.com",
           "password": "Aa1234!"
         }*/

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var appUser = await _userManager.FindByEmailAsync(loginModel.Email);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, loginModel.Password, false);

            if (appUser == null && signInResult.IsNotAllowed)
            {
                ModelState.AddModelError("email", "not found");

                return BadRequest(ModelState);
            }

            await _signInManager.SignInWithClaimsAsync(
                appUser,
                false,
                new Claim[]
                {
                    new Claim(OwnClaims.Description, appUser.Description)
                });

            return Ok();
        }

        // https://localhost:5001/Account/TokenLogin

        //admin role
        /*{
            "email": "admin@mail.com",
            "password": "Aa1234!"
          }*/

        //viewer role
        /*{
           "email": "viewer@mail.com",
           "password": "Aa1234!"
         }*/

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> TokenLogin(LoginModel loginModel)
        {
            var appUser = await _userManager.FindByEmailAsync(loginModel.Email);

            var signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, loginModel.Password, false);

            if (appUser == null && signInResult.IsNotAllowed)
            {
                ModelState.AddModelError("email", "not found");

                return BadRequest(ModelState);
            }

            var claim = new Claim(OwnClaims.Description, appUser.Description);

            await _signInManager.SignInWithClaimsAsync(
                appUser,
                false,
                new Claim[] { claim });

            var jwtSecurityToken = new JwtSecurityToken(
               issuer: AuthOptions.Issuer,
               audience: AuthOptions.Audience,
               notBefore: DateTime.UtcNow,
               claims: new Claim[] { claim },
               expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
               signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
           );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return new ObjectResult(new { user = appUser.Email, access_token = token });
        }
    }
}