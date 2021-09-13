using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        
        BL.ProductBL p = new BL.ProductBL();
        BL.LikeProduct lp = new BL.LikeProduct();
        BL.ShoppingCastBL scP = new BL.ShoppingCastBL();

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("addnewproduct")]
        public int AddNewProduct(ProductModel product)
        {
            return p.AddNewProduct(product);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("addtoshoppingcast")]
        public int AddToShppingCast(ShoppingCastModel product)
        {
            return scP.AddProductToShoppingCast(product);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("addtolikeproduct")]
        public int AddToLikeProduct(LikeProductModel product)
        {
            return lp.AddProductToLikeProduct(product);
        }

        [HttpGet]
        [Route("getlikeproducts/{userId}")]
        public List<ProductModel> GetProductInLikeProduct(int userId)
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(lp.GetProductInLikeProduct(userId));
        }

        [HttpGet]
        [Route("getshoppingcast/{userId}")]
        public List<ProductModel> GetProductInShoppingCast(int userId)
        {
            return scP.GetProductInShoppingCast(userId);
        }

        [HttpGet]
        [Route("getallproducts")]
        public List<ProductModel> GetAllProduct()
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetAllProducts());
        }
        [HttpGet]
        [Route("GetProductsOfUser/{userId}")]
        public List<ProductModel> GetProductsOfUser(int userId)
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductsOfUser(userId));
        }

        //[AcceptVerbs("POST")]
        //[HttpPost]
        //[Route("buyproducts")]
        //public List<ProductModel> BuyProducts(int codeUser)
        //{
        //    return DAL.Converts.ProductConvert.ConvertProductListToModel(p.BuyProducts(codeUser));
        //}

        [HttpGet]
        [Route("buyproducts/{codeUser}")]
        public List<ProductModel> BuyProducts(int codeUser)
        {
            List<Products> lp = new List<Products>();
            lp = p.BuyProducts(codeUser);
            if(lp != null)
                return DAL.Converts.ProductConvert.ConvertProductListToModel(lp);
            return null;
        }
    }
    }

