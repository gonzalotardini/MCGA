using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}