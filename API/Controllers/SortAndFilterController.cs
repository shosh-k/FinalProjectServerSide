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
    [RoutePrefix("api/sortandfilter")]
    public class SortAndFilterController : ApiController
    {

        BL.ProductBL p = new BL.ProductBL();

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("pricelowtohigt")]
        public List<ProductModel> GetProductsOrderByPriceLowToHigh(List<ProductModel> listOfProducts)
        {
            return p.GetProductsOrderByPriceLowToHigh(listOfProducts);
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("pricehightolow")]
        public List<ProductModel> GetProductsOrderByPriceHighToLow(List<ProductModel> listOfProducts)
        {
            return p.GetProductsOrderByPriceHighToLow(listOfProducts);
        }

        [AcceptVerbs("GET")]
        
        [Route("getproductorderbylocation/{userId}")]
        [HttpGet]
        public List<ProductModel> GetProductOrderByLocation(int userId)
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductOrderByLocation(userId));
        }

        [AcceptVerbs("POST")]
        [HttpPost]
        [Route("GetProductsOrderByStatus")]
        public List<ProductModel> GetProductsOrderByStatus(List<ProductModel> listOfProducts)
        {
            return p.GetProductsOrderByStatus(listOfProducts);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("filtercost/{num}")]
        public List<ProductModel> GetProductFilterCost(int num)
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductFilterCost(num));
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("producttomove")]
        public List<ProductModel> GetProductToMove()
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductToMove());
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("producttobuy")]
        public List<ProductModel> GetProductToBuy()
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductToBuy());
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getproductsbycategory/{codeCategory}")]
        public List<ProductModel> GetProductsByCategory(int codeCategory)
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductsByCategory(codeCategory));
        }

        [HttpGet]
        [Route("getproductsbysubcategory/{codeSubCategory}")]
        public List<ProductModel> GetProductsBySubCategory(int codeSubCategory)
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetProductsBySubCategory(codeSubCategory));
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getallnewproduct")]
        public List<ProductModel> GetAllNewProduct()
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetAllNewProduct());
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getalloldproduct")]
        public List<ProductModel> GetAllOldProduct()
        {
            return DAL.Converts.ProductConvert.ConvertProductListToModel(p.GetAllOldProduct());
        }
    }
}
