using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ConfArch.Data.Repositories;
using ConfArch.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace ConfArch.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            Response.Cookies.Append("MyCookie", "value1");
            var cookieValue = Request.Cookies["MyCookie"];
            var cookieValueNull = Request.Cookies["nonexistent"]; //return null
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("MyCookie", "value1", cookieOptions);
            Console.WriteLine($"\ncookieValue is {cookieValue}");
            var cookieExpires = Request.Cookies["MyCookie"].ToString();

            Console.WriteLine($"\ncookieExpires is {cookieExpires}");


            // Encryption
            // add data protection services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            var services = serviceCollection.BuildServiceProvider();

            // create an instance of MyClass using the service provider
            var instance = ActivatorUtilities.CreateInstance<EncryptData>(services);
            instance.RunSample();



            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = userRepository.GetByUsernameAndPassword(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("FavoriteColor", user.FavoriteColor)
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // note that can also set the expiresUTC property on the cookie to ensure
            // the cookie expires at some point
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = model.RememberLogin });

            return LocalRedirect(model.ReturnUrl);
        }

        [AllowAnonymous]
        public IActionResult LoginWithGoogle(string returnUrl = "/")
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleLoginCallback"),
                Items =
                {
                    { "returnUrl", returnUrl }
                }
            };
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallback()
        {
            // read google identity from the temporary cookie
            var result = await HttpContext.AuthenticateAsync(
                ExternalAuthenticationDefaults.AuthenticationScheme);

            var externalClaims = result.Principal.Claims.ToList();

            var subjectIdClaim = externalClaims.FirstOrDefault(
                x => x.Type == ClaimTypes.NameIdentifier);
            var subjectValue = subjectIdClaim.Value;

            var user = userRepository.GetByGoogleId(subjectValue);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("FavoriteColor", user.FavoriteColor)
            };

            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // delete temporary cookie used during google authentication
            await HttpContext.SignOutAsync(
                ExternalAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(result.Properties.Items["returnUrl"]);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }


    public class EncryptData
    {
        IDataProtector _protector;

        // the 'provider' parameter is provided by DI
        public EncryptData(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Contoso.MyClass.v1");
        }

        public void RunSample()
        {

            string input = "Here is some data to encrypt";

            // protect the payload
            string protectedPayload = _protector.Protect(input);
            Debug.WriteLine("\n\nEncrypted Data\\");
            Console.WriteLine($"Protect returned: {protectedPayload}");
            Debug.WriteLine($"Protect returned: {protectedPayload}");

            // unprotect the payload
            Debug.WriteLine("\n\nDecrypted Data\n"); 
            string unprotectedPayload = _protector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
            Debug.WriteLine($"Unprotect returned: {unprotectedPayload}");
        }
    }
}
