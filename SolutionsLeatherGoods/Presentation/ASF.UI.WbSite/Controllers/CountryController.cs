using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ASF.Entities;

namespace ASF.UI.WbSite.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        [HttpGet]
        public ActionResult Index()
        {
            var CountryProcess = new Process.CountryProcess();
            var List = new List<Country>();
            List = CountryProcess.SelectList();          
            return View(List);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create (Country country)
        {
            var countryProcess = new Process.CountryProcess();
            countryProcess.Create(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details (int id)
        {


            return View(id);
        }
    }
}