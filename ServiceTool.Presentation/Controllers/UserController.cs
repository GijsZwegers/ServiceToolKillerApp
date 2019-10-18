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
using ServiceTool.Presentation.Assets;
using ServiceTool.Presentation.Models;

namespace ServiceTool.Presentation.Controllers
{
    public class UserController : Controller
    {

        private AdminrUserCollection _serverUserCollection;
        private CompanyUserCollection _customerUserCollection;
        private UserCollection _userCollection;


        public UserController(IUserContext userContext, ICustomerUserContext customerUserContext)
        {
            _customerUserCollection = new CompanyUserCollection(customerUserContext);
            _userCollection = new UserCollection(userContext);
        }

        [AllowAnonymous]
        public IActionResult Admin()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Admin(LoginAdminViewModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid) return View(model);
            await _serverUserCollection.GetUserTokenAsync(model.Username, model.Password);

            AdminUser serviceuser =  await _serverUserCollection.getCustomerAsync();

            //ServiceUser serviceuser = serverUserCollection.Login(model.Email, model.Password);

            if (serviceuser == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            //INFO: Claims are use to specify properties of an Identity(a user)
            List<Claim> claims = new List<Claim>();
            if ((serviceuser != null))
            {
                claims = new List<Claim>
                {
                    new Claim("Name", serviceuser.Name),
                    new Claim("Role", Role.Admin.ToString()),
                    new Claim("Email", serviceuser.Mail),
                    new Claim(ClaimTypes.Role, Role.Admin)
                };
            }
            // 
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginCustomer(LoginCustomerViewModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid) return View(model);

            await _serverUserCollection.GetUserTokenAsync(model.Email, model.Password);
            AdminUser serviceUser = await _serverUserCollection.getCustomerAsync();

            //add function for when pin is filled in.
            CompanyUser customeruser = _customerUserCollection.Login(model.Email, model.Password);



            //TODO: Add code for Customer User

            if (customeruser == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }

            //INFO: Claims are use to specify properties of an Identity(a user)
            List<Claim> claims = null;
            if ((customeruser != null))
            {
                claims = new List<Claim>
                {
                    new Claim("Name", customeruser.Name),
                    new Claim("CompanyId", customeruser.CompanyId.ToString()),
                    new Claim("Role", Role.User.ToString()),
                    new Claim("Email", customeruser.Mail),
                    new Claim(ClaimTypes.Role, Role.User)
                };
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return LocalRedirect(returnUrl);
        }

        [AuthorizeRoles(Roles = Role.Admin)]
        public IActionResult Register()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid) return View(model);

            if (model.Password != model.PasswordCheck)
            {
                ModelState.AddModelError("", "The passwords don't match");
                return View(model);
            }

            //ServiceUser serviceUser = serverUserCollection.Register(model.Email, model.Password, model.Name, model.LastName);

            //ServiceUser serviceUser = new ServiceUser(_serviceUserContect.Login(model.Email, model.Password));

            //For testing
            return View("Login");
        }
    }
}