using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.Logic;
using ServiceTool.Presentation.Models;

namespace ServiceTool.Presentation.Controllers
{
    public class UserController : Controller
    {

        private ServerUserCollection serverUserCollection;

        public UserController(IServiceUserContext caseContext)
        {
            serverUserCollection = new ServerUserCollection(caseContext);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid) return View(model);

            ServiceUser serviceuser = serverUserCollection.Login(model.Email, model.Password);

            if (serviceuser == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            // INFO: Claims are use to specify properties of an Identity (a user)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, serviceuser.Name),
                new Claim(ClaimTypes.Role, serviceuser.Role),
                new Claim(ClaimTypes.Email, serviceuser.Mail)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return LocalRedirect(returnUrl);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid) return View(model);

            //ServiceUser serviceUser = new ServiceUser(_serviceUserContect.Login(model.Email, model.Password));

            //For testing
            return NoContent();
        }
    }
}