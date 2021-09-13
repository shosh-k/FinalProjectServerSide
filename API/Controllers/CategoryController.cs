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

    [RoutePrefix("api/category")]

    public class CategoryController : ApiController
    {
        BL.Category cat = new BL.Category();


        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getcategories")]
        public List<CategoryModel> GetCategories()
        {
            return DAL.Converts.CategoryConvert.ConvertCategoriesListToModel(cat.GetCategories());
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("getsubcategories/{codeCategory}")]
        public List<SubCategoryModel> GetSubCategories(int codeCategory)
        {
            return DAL.Converts.SubCategoryConvert.ConvertSubCategoryListToModel(cat.GetSubCategory(codeCategory));
        }
        
    }
}
