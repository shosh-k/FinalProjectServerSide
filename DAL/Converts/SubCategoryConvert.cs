using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class SubCategoryConvert
    {

        public static SubCategories ConvertSubCategoryToEF(SubCategoryModel subCategory)
        {
            return new SubCategories
            {
                CodeSubCategory = subCategory.CodeSubCategory,
                NameSubCategory = subCategory.NameSubCategory,
                CodeCategorySub = subCategory.CodeCategorySub
            };

        }
        public static SubCategoryModel ConvertSubCategoryToModel(SubCategories subCategory)
        {
            return new SubCategoryModel
            {
                CodeSubCategory = subCategory.CodeSubCategory,
                NameSubCategory = subCategory.NameSubCategory,
                CodeCategorySub = subCategory.CodeCategorySub
            };
        }

        public static List<SubCategoryModel> ConvertSubCategoryListToModel(IEnumerable<SubCategories> subCategory)
        {
            return subCategory.Select(c => ConvertSubCategoryToModel(c)).OrderBy(n => n.CodeSubCategory).ToList();
        }
    }
}
