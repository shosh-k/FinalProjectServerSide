using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/likeproduct")]
    public class LikeProductController : ApiController
    {
        BL.LikeProduct likeProduct = new BL.LikeProduct();

        //[AcceptVerbs("POST")]
        //[HttpPost]
        //[Route("deletefromlikeproduct")]
        //public int DeleteFromLikeProduct(int codeProduct)
        //{
        //    return likeProduct.DeleteFromLikeProduct(codeProduct);
        //}

        [HttpGet]
        [Route("DeleteFromLikeProduct/{codeProduct}")]

        public int DeleteFromLikeProduct(int codeProduct)
        {
            return likeProduct.DeleteFromLikeProduct(codeProduct);
        }

    }
}
