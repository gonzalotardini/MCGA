using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace ASF.UI.WbSite.Areas.Categories.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categories/Category
        public ActionResult Index()
        {
            var CategoryProcess = new Process.CategoryProcess();
            var Lista = CategoryProcess.SelectList();
            return View(Lista);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create (Entities.Category category)
        {
            var principal = Thread.CurrentPrincipal.Identity.Name;
            var CategoryProcess = new Process.CategoryProcess();
            CategoryProcess.Create(category);
           
            return RedirectToAction("Index");
        }


        public ActionResult Update(Category category) {

            var categoryprocess = new Process.CategoryProcess();
            categoryprocess.Update(category);

            return RedirectToAction("Index");
        }
    }
}