using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class CategoryConvert
    {

        public static Categories ConvertCategoryToEF(CategoryModel category)
        {
            return new Categories
            {
                CodeCategory = category.CodeCategory,
                NameCategory = category.NameCategory

            };
        }
        public static CategoryModel ConvertCategoryToModel(Categories category)
        {
            return new CategoryModel
            {
                CodeCategory = category.CodeCategory,
                NameCategory = category.NameCategory
            };
        }



        public static List<CategoryModel> ConvertCategoriesListToModel(IEnumerable<Categories> category)
        {
            return category.Select(c => ConvertCategoryToModel(c)).OrderBy(n => n.CodeCategory).ToList();
        }
    }
}
