using ASF.Data.DbContext;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult UpdateCart (int cantidad, int productId, double price)
        {
            var email = User.Identity.Name;
            var cartProcess = new CartProcess();

            cartProcess.AddToCart(cantidad, productId, email,price);

            return RedirectToAction("Index", "Product");
        }
    }
}