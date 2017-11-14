using ASF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var clientProcess = new Process.ClientProcess();
            var ListaClientes = clientProcess.SelectList();   

            
            return View(ListaClientes);
        }


    }
}