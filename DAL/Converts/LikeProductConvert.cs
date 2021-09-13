using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class LikeProductConvert
    {
        public static LikeProducts ConvertLikePorductToEF(LikeProductModel likeProduct)
        {
            return new LikeProducts
            {
                CodeLikeProduct = likeProduct.CodeLikeProduct,
                CodeProduct = likeProduct.CodeProduct,
                CodeUser = likeProduct.CodeUser
            };

        }
        public static LikeProductModel ConvertLikeProductToModel(LikeProducts likeProduct)
        {
            return new LikeProductModel
            {
                CodeLikeProduct = likeProduct.CodeLikeProduct,
                CodeProduct = likeProduct.CodeProduct,
                CodeUser = likeProduct.CodeUser
            };
        }

        public static List<LikeProductModel> ConvertLikeProductListToModel(IEnumerable<LikeProducts> likeProduct)
        {
            return likeProduct.Select(c => ConvertLikeProductToModel(c)).OrderBy(n => n.CodeLikeProduct).ToList();
        }

    }
}
