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

        private AdminUserCollection _adminUserCollection;
        private CompanyUserCollection _companyUserCollection;
        //private UserCollection _userCollection;


        public UserController(IUserContext userContext,  IAdminUserContext adminUserContext)
        {
            _adminUserCollection = new AdminUserCollection(adminUserContext);
            _companyUserCollection = new CompanyUserCollection(userContext);
            //_userCollection = new UserCollection(userContext);
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
            //await _serverUserCollection.GetUserTokenAsync(model.Username, model.Password);

            AdminUser serviceuser =  await _adminUserCollection.Login(model.Username, model.Password);

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

            //await _serverUserCollection.GetUserTokenAsync(model.Email, model.Password);
            //AdminUser serviceUser = await _serverUserCollection.getCustomerAsync();
            CompanyUser companyUser = new CompanyUser();


            companyUser = await _companyUserCollection.Login(model.Email, model.Password, model.pin);
            
            //TODO: add function for when pin is filled in.

            if (companyUser == null)
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
                return View(model);
            }
            

            //INFO: Claims are use to specify properties of an Identity(a user)
            List<Claim> claims = null;
            if ((companyUser != null))
            {
                claims = new List<Claim>
                {
                    new Claim("Name", companyUser.Name),
                    new Claim("CompanyId", companyUser.CompanyId.ToString()),
                    new Claim("Role", Role.User.ToString()),
                    new Claim("Email", companyUser.Mail),
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
    }
}