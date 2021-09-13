using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DAL;
using BL.Dijkstra;
using Models;

namespace BL
{
    public class ProductBL: ComforTableBL
    {

        public ProductBL()
        {
        }
        ////הצגת מוצר שנבחר
        //public List<Products> GetProduct(Products product)
        //{
        //    return dbCon.GetDbSet<Products>().Where(p => p.CodeProduct == product.CodeProduct).ToList();
        //}
        //מביא מוצר לפי קוד מוצר
        public Products GetProductById(int CodeProduct)
        {
            return dbCon.GetDbSet<Products>().First(p => p.CodeProduct == CodeProduct);
        }
        //הצגת כל המוצרים
        public List<Products> GetAllProducts()
        {
            return dbCon.GetDbSet<Products>().Where(p => p.ProductSold == 0).ToList();
        }
        //הצגת מוצרים לפי קטגוריה
        public List<Products> GetProductsByCategory(int codeCategory)
        {
            return GetAllProducts().Where(p => p.CategoryProduct == codeCategory).ToList();
        }
        //הצגת מוצרים לפי תת קטגוריה
        public List<Products> GetProductsBySubCategory(int codeSubCategory)
        {
            return GetAllProducts().Where(p => p.SubCategoryProduct == codeSubCategory).ToList();
        }

        //הצגת מוצרים למסירה
        public List<Products> GetProductToMove()
        {
            return GetAllProducts().Where(p => p.MoveOrBuy == 0).ToList();
        }
        //הצגת מוצרים למכירה
        public List<Products> GetProductToBuy()
        {
            return dbCon.GetDbSet<Products>().Where(p => p.MoveOrBuy == 1).ToList();
        }
        //הצגת מוצרים חדשים
        public List<Products> GetAllNewProduct()
        {
            return GetAllProducts().Where(p => p.NewOrOld == 1).ToList();
        }
        //הצגת מוצרים ישנים
        public List<Products> GetAllOldProduct()
        {
            return GetAllProducts().Where(p => p.NewOrOld == 0).ToList();
        }
        //הצגת מוצרים שעלותם נמוכה מהמספר שהתקבל
        public List<Products> GetProductFilterCost(int num)
        {
            return GetAllProducts().Where(p => p.PriceProduct <= num).ToList();
        }
        //הצגת מוצרים ממוינים לפי מחיר מהנמוך לגבוה
        public List<ProductModel> GetProductsOrderByPriceLowToHigh(List<ProductModel> listOfProduct)
        {
            List<ProductModel> list = new List<ProductModel>();
            return listOfProduct.OrderBy(p => p.PriceProduct).ToList();
        }
        //הצגת מוצרים ממוינים לפי מחיר מהגבוה לנמוך
        public List<ProductModel> GetProductsOrderByPriceHighToLow(List<ProductModel> listOfProduct)
        {
            return listOfProduct.OrderByDescending(p => p.PriceProduct).ToList();
        }
        //הצגת מוצרים ממוינים לפי דרוגם
        public List<ProductModel> GetProductsOrderByStatus(List<ProductModel> listOfProduct)
        {
            return listOfProduct.OrderByDescending(p => p.StatusProduct).ToList();
        }
        //הצגת מוצרים של מוכר מסוים
        public List<Products> GetProductsOfUser(int userId)
        {
            return GetAllProducts().Where(p => p.CodeSallerProduct == userId).ToList();
        }
        //הצג מוצרים ממוינים לפי קירבת המוצר ללקוח מהקרוב לרחוק 
        public List<Products> GetProductOrderByLocation(int CodeUser)
        {
            User u = new User();
            MapsService alg = new MapsService();
            Users user = u.GetUserById(CodeUser);
            SortedList<int, List<Products>> dic = new SortedList<int, List<Products>>();
            string FullAdressUser = user.AddresstUser;
            var listOfProduct = GetAllProducts();
            foreach (var p in listOfProduct)
            {
                var saller = u.GetUserById(int.Parse(p.CodeSallerProduct.ToString()));
                string FullAdressProduct = saller.AddresstUser;
                var resultDistance = int.Parse(alg.GetDistance(FullAdressUser, FullAdressProduct).Result.Split(' ', '.')[0]);
                if (dic.Keys.Contains(resultDistance))
                    dic[resultDistance].Add(p);
                else
                {
                    List<Products> lp = new List<Products>()
                    {
                        p
                    };
                    dic.Add(resultDistance, lp);

                }
            }
            List<Products> listToReturn = new List<Products>();
            foreach(var d in dic.Keys)
            {
                foreach(var listInD in dic[d])
                {
                    listToReturn.Add(listInD);
                }

            }

            return listToReturn;
        }
        
        //הוספת מוצר למערכת
        public int AddNewProduct(ProductModel pro)
        {
            try
            {
                AddToDB<Products>(DAL.Converts.ProductConvert.ConvertProductToEF(pro));
                //return dbCon.GetDbSet<ProductModel>().ToList().Find(a => a.CodeProduct == pro.CodeProduct).CodeProduct;
                return dbCon.GetDbSet<Products>().ToList().Last().CodeProduct;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        //טיפול בקניית מוצרים
        public List<Products> BuyProducts(int codeUser)
        {
            ShoppingCastBL scBL = new ShoppingCastBL();
            LikeProduct lpBL = new LikeProduct();
            ShoppingCastModel sp;
            LikeProductModel lp;
            EmailAndPayPal eAndp = new EmailAndPayPal();
            Dijkstra.Dijkstra dijkstra = new Dijkstra.Dijkstra();
            User u = new User();
            try
            {   
                var pro = lpBL.GetProductInLikeProduct(codeUser);
                //eAndp.PayOfAppearance(cardNum, threeLetters, effect, sumOfPay);
                foreach (var p in pro)
                {
                    if(eAndp.SendMailToUser(u.GetUserById(codeUser), p, 1) == 0)
                        return null;
                    if(eAndp.SendMailToUser(u.GetUserById(int.Parse(p.CodeSallerProduct.ToString())), p, 0)==0)
                        return null;
                    sp = new ShoppingCastModel() {

                        CodeProduct = p.CodeProduct,
                        CodeUser = codeUser
                    };
                    scBL.AddProductToShoppingCast(sp);
                    p.ProductSold = 1;
                    UpdateDB<Products>(p);
                }
                List<Products> path = dijkstra.MainDijkstraPath(codeUser);
                foreach (var p in pro)
                {
                    lpBL.DeleteFromLikeProduct(p.CodeProduct);
                }

                return path;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}


