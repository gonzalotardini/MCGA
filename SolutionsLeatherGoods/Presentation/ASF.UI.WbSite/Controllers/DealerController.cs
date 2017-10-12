using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            var dealerProcess = new DelaerProcess();
            var ListaDealers = dealerProcess.SelectAll();
            return View(ListaDealers);
        }
    }
}