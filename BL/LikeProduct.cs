using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LikeProduct: ComforTableBL
    {
        public LikeProduct()
        {

        }
        //הצגת כל הערכים שבטבלה
        public List<LikeProducts> GetAllLikeProducts(int codeUser)
        {
            return dbCon.GetDbSet<LikeProducts>().Where(u => u.CodeUser == codeUser).ToList();
        }

        //הצגת מוצרים שlikeProduct
        public List<Products> GetProductInLikeProduct(int codeUser)
        {
            ProductBL p = new ProductBL();
            var lp = GetAllLikeProducts(codeUser);
            List<Products> productInLikeProduct = new List<Products>();
            foreach (var l in lp)
            {
                productInLikeProduct.Add(p.GetProductById(int.Parse(l.CodeProduct.ToString())));
            }
            return productInLikeProduct;
        }
        //מביא מוצר שאהב לפי קוד מוצר
        public LikeProducts getLikeProductById(int codeProduct)
        {
            var set = dbCon.GetDbSet<LikeProducts>();
            if (set.Any(c => c.CodeProduct == codeProduct))
                return set.First(c => c.CodeProduct == codeProduct);
            return null;
        }
        //הוספת מוצר לטבלת המוצרים שאהב
        public int AddProductToLikeProduct(LikeProductModel lp)
        {
            try
            {
                //check if product exist in table
                if (getLikeProductById(int.Parse(lp.CodeProduct.ToString())) == null || (getLikeProductById(int.Parse(lp.CodeProduct.ToString())) != null && getLikeProductById(int.Parse(lp.CodeProduct.ToString())).CodeUser != lp.CodeUser))
                {
                    //if not exist
                    AddToDB<LikeProducts>(DAL.Converts.LikeProductConvert.ConvertLikePorductToEF(lp));
                }
                return dbCon.GetDbSet<LikeProducts>().ToList().Find(a => (a.CodeProduct == lp.CodeProduct) && (a.CodeUser == lp.CodeUser)).CodeLikeProduct;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        //מחיקת מוצר מטבלת המוצרים שאהב
        public int DeleteFromLikeProduct(int codePtoduct)
        {
            try
            {
                LikeProducts lp = getLikeProductById(codePtoduct);
                //check if product exist in table
                if (lp != null)
                {
                    //if exist
                    DeleteDB<LikeProducts>(lp);
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
