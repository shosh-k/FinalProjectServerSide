using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/shoppingcast")]

    public class ShoppingCastController : ApiController
    {
        BL.ShoppingCastBL shoppingCast = new BL.ShoppingCastBL();

        //[HttpPost]
        //[Route("deletefromshoppingcast")]
        //public int DeleteFromShoppingCast(int codeProduct)
        //{
        //    return shoppingCast.DeleteFromShoppingCast(codeProduct);
        //}

        [HttpGet]
        [Route("deletefromshoppingcast/{codeProduct}")]

        public int DeleteFromShoppingCast(int codeProduct)
        {
            return shoppingCast.DeleteFromShoppingCast(codeProduct);
        }

    }
}
