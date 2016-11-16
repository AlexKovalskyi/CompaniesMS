using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using CompaniesMSWebApp.DataStubs;
using CompaniesMSWebApp.Models.CompaniesMS;

namespace CompaniesMSWebApp.Controllers
{
    public class CompaniesMSController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Tree of companies.";
            IList<Company> companies = new DataStub().GetCompany();

            return View(companies);
        }
    }
}
