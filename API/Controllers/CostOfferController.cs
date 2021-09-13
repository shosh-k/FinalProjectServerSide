using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/costoffer")]
    public class CostOfferController : ApiController
    {
        BL.CostOffer c = new BL.CostOffer();


        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costofferbed/{type}")]
        public int CostOfferBed(int type)
        {
            return c.Beds(type);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costoffercloset/{numOfDor}")]
        public int CostOfferCloset(int numOfDor)
        {
            return c.Closets(numOfDor);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costoffertable/{numOfMeters}/{needPeruk}")]
        public int CostOfferTable( int numOfMeters,Boolean needPeruk)
        {
            return c.Tables(numOfMeters, needPeruk);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costofferchair/{cost}/{numOfChairs}")]
        public int CostOfferChair( int numOfChairs)
        {
            return c.Chairs( numOfChairs);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costoffershidot/{needPeruk}")]
        public int CostOfferShidot( Boolean needPeruk)
        {
            return c.Shidot(needPeruk);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costoffersoffa/{numOfMeters}")]
        public int CostOfferSoffa(int numOfMeters)
        {
            return c.Soffas(numOfMeters);
        }
        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("costofferdelivery/{userId}/{codeProduct}")]
        public int CostOfferDelivery(int userId, int codeProduct)
        {
            return c.GetCostByDijkstraToProduct(userId, codeProduct);
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("GetCostByDijkstraShoppingCast")]
        public int GetCostByDijkstraShoppingCast()
        {
            return c.GetCostByDijkstraShoppingCast();
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("submitAvgBed/{type}/{cost}")]
        public int SubmitAvgBed(int type, int cost)
        {
            try
            {
                c.avgBeds(type, cost);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("submitAvgChairs/{numOfChairs}/{cost}")]
        public int SubmitAvgChairs(int numOfChairs, int cost)
        {
            try
            {
                c.avgChairs(cost, numOfChairs);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("submitAvgClosets/{numOfDor}/{cost}")]
        public int SubmitAvgClosets(int numOfDor, int cost)
        {
            try
            {
                c.avgClosets(cost, numOfDor);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("submitAvgShidot/{type}/{cost}")]
        public int SubmitAvgShidot(int type, int cost)
        {
            try
            {
                c.avgShidot(type, cost);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("submitAvgSoffas/{numOfMeter}/{cost}")]
        public int SubmitAvgSoffas(int numOfMeter, int cost)
        {
            try
            {
                c.avgSoffas(cost, numOfMeter);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("submitAvgTables/{numOfMeter}/{cost}/{type}")]
        public int SubmitAvgTables(int numOfMeter, int cost, int type)
        {
            try
            {
                c.avgTables(type, cost, numOfMeter);
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }









        //[AcceptVerbs("POST")]
        //[HttpPost]
        //[Route("GetCostDisassemblyandassembly/{ListOfProducts}")]
        //public List<ProductModel> GetCostDisassemblyandassembly(List<ProductModel> ListOfProducts)
        //{
        //    return c.GetProductsOrderByPriceLowToHigh(listOfProducts);
        //}

    }
}
