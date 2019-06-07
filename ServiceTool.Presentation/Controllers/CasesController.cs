using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceTool.DAL.ContextInterfaces;
using ServiceTool.Logic;
using ServiceTool.Presentation.Assets;
using ServiceTool.Presentation.Models;

namespace ServiceTool.Presentation.Controllers
{
    public class CasesController : Controller
    {
        private Logic.Case Case;
        private Logic.CaseCollection CaseCollection;

        public CasesController(ICaseContext caseContext)
        {
            Case = new Logic.Case(caseContext);
            CaseCollection = new Logic.CaseCollection(caseContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeRoles(Role.Admin)]
        public IActionResult AllCasesPart()
        {
            CaseViewModel csvm = new CaseViewModel(CaseCollection.GetAllCases());

            return PartialView(csvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public JsonResult LoadAllCases()
        {
            try
            {
                var data = CaseCollection.GetAllCases();

                return new JsonResult(data);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                return new JsonResult(new { error = "Internal Server Error" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StorageLocations(bool isHardcover)
        {
            //var locations = _locations.Where(x => x.IsHardcover).ToList();

            throw new NotImplementedException();
        }
    }
}