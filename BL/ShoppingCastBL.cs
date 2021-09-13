using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ShoppingCastBL:ComforTableBL
    {
        public ShoppingCastBL()
        {

        }
        //הצגת כל הערכים שבטבלה
        public List<ShoppingCast> GetAllShoppingCast(int codeUser)
        {
            return dbCon.GetDbSet<ShoppingCast>().Where(u => u.CodeUser == codeUser).ToList();
        }

        //הצגת מוצרים שבעגלת קניות
        public List<ProductModel> GetProductInShoppingCast(int codeUser)
        {
            ProductBL p = new ProductBL();
            var sc = GetAllShoppingCast(codeUser);
            List<ProductModel> productInShoppingCast = new List<ProductModel>();
            foreach (var s in sc)
            {
                productInShoppingCast.Add(DAL.Converts.ProductConvert.ConvertProductToModel(p.GetProductById(int.Parse(s.CodeProduct.ToString()))));
            }
            return productInShoppingCast;
        }

        //מביא מוצר שקנה לפי קוד מוצר
        public ShoppingCast getShoppingCastById(int codeProduct)
        {
            var set = dbCon.GetDbSet<ShoppingCast>();
            if (set.Any(c => c.CodeProduct == codeProduct))
                return set.First(c => c.CodeProduct == codeProduct);
            return null;
        }
        //הוספת מוצר לטבלת עגלת קניות
        public int AddProductToShoppingCast(ShoppingCastModel sp)
        {
            try
            {
                //check if product exist in table
                if (getShoppingCastById(int.Parse(sp.CodeProduct.ToString())) == null)
                {
                    //if not exist
                    AddToDB<ShoppingCast>(DAL.Converts.ShoppingCastConvert.ConvertShoppingCastToEF(sp));
                }
                return dbCon.GetDbSet<ShoppingCast>().ToList().Find(a => a.CodeProduct == sp.CodeProduct).CodeShoppingCast;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        //מחיקת מוצר מטבלת עגלת קניות ומהמערכת
        public int DeleteFromShoppingCast(int codePtoduct)
        {
            try
            {
                ShoppingCast sp = getShoppingCastById(codePtoduct);
                ProductBL pBL = new ProductBL();
                Products pToDelete = pBL.GetProductById(codePtoduct);
                //check if product exist in table
                if (sp != null)
                {
                    //if exist
                    DeleteDB<ShoppingCast>(sp);
                    DeleteDB<Products>(pToDelete);
                }
                return codePtoduct;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

    }
}
