using ASF.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
    public class CartProcess:ProcessComponent
    {
        public void AddToCart(int cantidad, int ProductId, string email, double price)
        {
            var cartBussines = new CartBusiness();

            cartBussines.AddToCart(cantidad, ProductId, email, price);
        }


    }
}
