using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BL.Dijkstra
{
    class Dijkstra
    {
        public static int numOfKiloMeters;
        public static int numOfProduct;

        User u = new User();
        MapsService alg = new MapsService();
        SortedList<string, Products> dic = new SortedList<string, Products>();
        ProductBL p = new ProductBL();
        LikeProduct lp = new LikeProduct();
        List<Products> path = new List<Products>();

        public Dijkstra()
        {
            numOfKiloMeters = 0;
            numOfProduct = 1;
        }

        public Products GetFirstNode(Users destination, List<ProductModel> product)
        {
            try
            {
                foreach (var p in product)
                {
                    var saller = u.GetUserById(int.Parse(p.CodeSallerProduct.ToString()));
                    dic[alg.GetDistance(destination.AddresstUser, saller.AddresstUser).ToString()] = DAL.Converts.ProductConvert.ConvertProductToEF(p);
                }
            
                    return dic.Last().Value;
                }
            catch (Exception)
            {
                return null;
            }
        }


        public (Products, int) NextDestination(int codeUser, List<ProductModel> product)
        {
            Users user = u.GetUserById(codeUser);
            SortedList<string, Products> dic = new SortedList<string, Products>();
            string FullAdressOrigin = user.AddresstUser;
            foreach (var p in product)
            {
                var saller = u.GetUserById(int.Parse(p.CodeSallerProduct.ToString()));
                string FullAdressProduct = saller.AddresstUser;
                dic[alg.GetDistance(FullAdressOrigin, FullAdressProduct).Result] = DAL.Converts.ProductConvert.ConvertProductToEF(p);
            }
            return (dic.First().Value, int.Parse(dic.First().Key.Split(' ','.')[0]));
        }
        public string GetLastNode(int codeUser, int codeProduct)
        {
            try
            {
                Users user = u.GetUserById(codeUser);
                string FullAdressUser = user.AddresstUser;
                var saller = u.GetUserById(int.Parse(p.GetProductById(codeProduct).CodeSallerProduct.ToString()));
                string FullAdressProduct = saller.AddresstUser;

                return alg.GetDistance(FullAdressUser, FullAdressProduct).Result;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Products> MainDijkstraPath(int codeUser)
        {
            try
            {
                var destination = u.GetUserById(codeUser);
                var products = lp.GetProductInLikeProduct(codeUser);
                var temp = products;
                numOfProduct = products.Count();
                var FirstNode = GetFirstNode(destination, DAL.Converts.ProductConvert.ConvertProductListToModel(products));
                path.Add(FirstNode);
                products = products.Where(p => p.CodeProduct != FirstNode.CodeProduct).ToList();
                temp = products.Where(p => p.CodeProduct != FirstNode.CodeProduct).ToList();
                foreach (var p in products)
                {
                    var (next, num) = NextDestination(int.Parse(path.Last().CodeSallerProduct.ToString()), DAL.Converts.ProductConvert.ConvertProductListToModel(temp));
                    path.Add(next);
                    temp = temp.Where(p1 => p1.CodeProduct != next.CodeProduct).ToList();
                    numOfKiloMeters += num;
                }

                try
                {
                    numOfKiloMeters += int.Parse(GetLastNode(codeUser, path.Last().CodeProduct).Split(' ', '.')[0]);

                }
                catch (Exception)
                {

                    return null;
                }
                return path;

            }
            catch (Exception)
            {
                return null;
            }

        }
        public (int, int) DijkstraKilometters()
        {
            return (numOfKiloMeters, numOfProduct);
        }
    }
}

