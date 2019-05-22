using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.Presentation.Models;

namespace ServiceTool.Presentation.Controllers
{
    public class UserController : Controller
    {

        private readonly IServiceUserContext _serviceUserContect;

        public UserController(IServiceUserContext serviceUserContext)
        {
            _serviceUserContect = serviceUserContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            // Lets first check if the Model is valid or not
            if (!ModelState.IsValid) return View(model);

            _serviceUserContect.Login(model.Email, model.Password);


            //For testing
            return NoContent();
        }
    }
}