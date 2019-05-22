using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Repositorys;
using ServiceTool.Logic;
using ServiceTool.Presentation.Models;

namespace ServiceTool.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICaseContext _caseContext;

        public HomeController(ICaseContext caseContext)
        {
            _caseContext = caseContext;
        }

        public IActionResult Index()
        {
            //Case caseStatus = new Case(_caseContext.Get(1)); this was just for testing ^^
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            //// Lets first check if the Model is valid or not
            //if (!ModelState.IsValid) return View(model);

            //// Then try to find the user; if not exists we will not try to login
            //User user = _repository.GetUserByName(model.Username);
            //if (user == null)
            //{
            //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
            //    return View(model);
            //}
            return NoContent();
        }


            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
