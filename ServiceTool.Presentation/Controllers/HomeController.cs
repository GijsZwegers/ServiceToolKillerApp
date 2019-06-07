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
        private Logic.Case Case;
        private ServerUserCollection serverUserCollection;
        private CaseCollection CaseCollection;

        public HomeController(IServiceUserContext serviceusercontext, ICaseContext caseContext)
        {
            serverUserCollection = new ServerUserCollection(serviceusercontext);
            Case = new Logic.Case(caseContext);
            CaseCollection = new CaseCollection(caseContext);
        }


        public IActionResult Index()
        {
            CaseViewModel csvm = new CaseViewModel();
            if (User.HasClaim("Role", Role.Admin))
            {
                csvm = new CaseViewModel(CaseCollection.GetAllCases());
            }
            if (User.HasClaim("Role", Role.User))
            {
                var CompanyId = User.FindFirst("CompanyId").Value;

                csvm = new CaseViewModel(CaseCollection.GetCasesForCompany(Convert.ToInt32(CompanyId)));
            }
            return View(csvm);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AuthorizeRoles(Role.User, Role.Admin)]
        public JsonResult GetCasesForCompany()
        {
            return Json("");
        }

        [AuthorizeRoles(Role.Admin)]
        public JsonResult GetAllCases()
        {
            CaseCollection.GetAllCases();
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
