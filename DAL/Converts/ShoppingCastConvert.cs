using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class ShoppingCastConvert
    {

        public static ShoppingCast ConvertShoppingCastToEF(ShoppingCastModel shoppingCast)
        {
            return new ShoppingCast
            {
                CodeShoppingCast = shoppingCast.CodeShoppingCast,
                CodeProduct = shoppingCast.CodeProduct,
                CodeUser = shoppingCast.CodeUser
            };

        }
        public static ShoppingCastModel ConvertShoppingCastToModel(ShoppingCast shoppingCast)
        {
            return new ShoppingCastModel
            {
                CodeShoppingCast = shoppingCast.CodeShoppingCast,
                CodeProduct = shoppingCast.CodeProduct,
                CodeUser = shoppingCast.CodeUser
            };
        }

        public static List<ShoppingCastModel> ConvertShoppingCastListToModel(IEnumerable<ShoppingCast> ShoppingCast)
        {
            return ShoppingCast.Select(c => ConvertShoppingCastToModel(c)).OrderBy(n => n.CodeShoppingCast).ToList();
        }
    }
}
