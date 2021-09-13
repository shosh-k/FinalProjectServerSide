using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class ProductConvert
    {

        public static Products ConvertProductToEF(ProductModel product)
        {
            return new Products
            {
                CodeProduct = product.CodeProduct,
                NameProduct = product.NameProduct,
                CategoryProduct = product.CategoryProduct,
                SubCategoryProduct = product.SubCategoryProduct,
                CodeSallerProduct = product.CodeSallerProduct,
                PriceProduct = product.PriceProduct,
                DescriptionProduct = product.DescriptionProduct,
                StatusProduct = product.StatusProduct,
                MoveOrBuy = product.MoveOrBuy,
                NewOrOld = product.NewOrOld,
                ProductSold = product.ProductSold


            };
        }
        public static ProductModel ConvertProductToModel(Products product)
        {
            return new ProductModel
            {
                CodeProduct = product.CodeProduct,
                NameProduct = product.NameProduct,
                CategoryProduct = product.CategoryProduct,
                SubCategoryProduct = product.SubCategoryProduct,
                CodeSallerProduct = product.CodeSallerProduct,
                PriceProduct = product.PriceProduct,
                DescriptionProduct = product.DescriptionProduct,
                StatusProduct = product.StatusProduct,
                MoveOrBuy = product.MoveOrBuy,
                NewOrOld = product.NewOrOld,
                ProductSold = product.ProductSold
            };
        }



        public static List<ProductModel> ConvertProductListToModel(IEnumerable<Products> product)
        {
            return product.Select(c => ConvertProductToModel(c)).OrderBy(n => n.CodeProduct).ToList();
        }
    }
}

