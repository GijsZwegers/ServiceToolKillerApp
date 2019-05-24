using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.DAL.Repositorys;
using ServiceTool.Logic;
using ServiceTool.Presentation.Assets;
using ServiceTool.Presentation.Models;

namespace ServiceTool.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ServerUserCollection serverUserCollection;

        public HomeController(IServiceUserContext caseContext)
        {
            serverUserCollection = new ServerUserCollection(caseContext);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [AuthorizeRoles(Role.Admin, Role.User)]
        public JsonResult GetForCompanyCases()
        {
            return Json("");
        }

        [Authorize(Roles = "Service Medewerker")]
        public JsonResult GetAllCases()
        {
            return Json("");
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
