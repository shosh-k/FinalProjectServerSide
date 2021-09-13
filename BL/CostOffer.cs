using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CostOffer
    {

        public CostOffer()
        {
         
        }
            //מחיר עבור מיטה
            //סוג 1-יחיד
            //2- זוגי
            //3- מיטה וחצי
            //4 - תינוק
        static List<int>  arrCosts = new List<int>() { 200,400,300,150};
        public static Dictionary<int, List<int>> BadCosts = new Dictionary<int, List<int>>() { 
            { 0, new List<int>() },
            { 1, new List<int>() },
            { 2, new List<int>() },
            { 3, new List<int>() },
        };
        public int Beds(int type)
        {
            int totalCost = 0;
            switch (type)
            {
                case 1:
                    totalCost = arrCosts[0];
                    break;

                case 2:
                    totalCost  = arrCosts[1];
                    break;

                case 3:
                    totalCost  = arrCosts[2];
                    break;

                case 4:
                    totalCost  = arrCosts[3];
                    break;
            }

            return totalCost;
        }
        public void avgBeds(int index,int cost)
        {
            BadCosts[index].Add(cost);
            int avg = 0;
            if (BadCosts[index].Count==5)
            {
                avg = BadCosts[index][0]+ BadCosts[index][1]+ BadCosts[index][2]+ BadCosts[index][3]+ 
                    BadCosts[index][4];
                BadCosts[index].Clear();
            }
            arrCosts[index] = avg / 5;
        }


        static int costClosets = 150;
        static List<int> listClosets = new List<int>();
        public int Closets( int numOfDoors)
        {
            return numOfDoors * costClosets;
        }
        public void avgClosets(int cost,int num)
        {
            listClosets.Add(cost/num);
            int avg = 0;
            if (listClosets.Count == 5)
            {
                avg = listClosets[0] + listClosets[1] + listClosets[2] + listClosets[3] + listClosets[4];
                listClosets.Clear();
            }
            costClosets = avg / 5;
        }


        List<int> arrTables = new List<int>() { 150 ,200};
        public Dictionary<int, List<int>> TablesCosts = new Dictionary<int, List<int>>() {
          { 0, new List<int>() },
            { 1, new List<int>() },};
        public int Tables( int numOfMeters, bool neendsPeruk)
        {
            if (!neendsPeruk)
                return  numOfMeters * arrTables[0];
            else
                return  numOfMeters * arrTables[1];
        }
        public void avgTables(int index, int cost,int meters)
        {
            TablesCosts[index].Add(cost/meters);
            int avg = 0;
            if (TablesCosts[index].Count == 5)
            {
                avg = TablesCosts[index][0] + TablesCosts[index][1] + TablesCosts[index][2] + 
                    TablesCosts[index][3] + TablesCosts[index][4];
                TablesCosts[index].Clear();
            }
            arrTables[index] = avg / 5;
        }


        static int costChair = 50;
        static List<int> listChairs = new List<int>();
        public int Chairs( int numOfChairs)
        {
            return  costChair * numOfChairs;
        }
        public void avgChairs(int cost, int numOfChairs)
        {
            costChair=(cost / numOfChairs);
            int avg = 0;
            if (listChairs.Count == 5)
            {
                avg = listChairs[0] + listChairs[1] + listChairs[2] + listChairs[3] + listChairs[4];
                listChairs.Clear();
            }
            costChair = avg / 5;
        }


        static  List<int> arrShidot = new List<int>() { 300, 100 };
        static public Dictionary<int, List<int>> ShidotCosts = new Dictionary<int, List<int>>() {   { 0, new List<int>() },
            { 1, new List<int>() },};
        public int Shidot( bool needsPeruk)
        {
            if (needsPeruk)
                return arrShidot[0];
            return  arrShidot[1];
        }
        public void avgShidot(int index, int cost)
        {
            ShidotCosts[index].Add(cost);
            int avg = 0;
            if (ShidotCosts[index].Count == 5)
            {
                avg = ShidotCosts[index][0] + ShidotCosts[index][1] + ShidotCosts[index][2] + 
                    ShidotCosts[index][3] + ShidotCosts[index][4];
                ShidotCosts[index].Clear();
            }
            arrShidot[index] = avg / 5;
        }


       static int costSoffa = 200;
       static List<int> listSoffas = new List<int>();
        public int Soffas(int numOfMeters)
        {
            return  numOfMeters * costSoffa;
        }
        public void avgSoffas(int cost, int num)
        {
            listSoffas.Add(cost / num);
            int avg = 0;
            if (listSoffas.Count == 5)
            {
                avg = listSoffas[0] + listSoffas[1] + listSoffas[2] + listSoffas[3] + listSoffas[4];
                listSoffas.Clear();
            }
            costSoffa = avg / 5;
        }

        public int GetCostByDijkstraShoppingCast()
        {
            //Dijkstra.Dijkstra dijkstra = new Dijkstra.Dijkstra();
            //var (numOfKiloMeters, numOfProduct) = dijkstra.DijkstraKilometters();
            return BL.Dijkstra.Dijkstra.numOfKiloMeters * 20 + BL.Dijkstra.Dijkstra.numOfProduct *20;
        }
        public int GetCostByDijkstraToProduct(int codeUser, int codeProduct)
        {
            try
            {
                Dijkstra.Dijkstra dijkstra = new Dijkstra.Dijkstra();
                var aaa = dijkstra.GetLastNode(codeUser, codeProduct).Split(' ','.');
                int numOfKiloMeters = int.Parse(aaa[0]);
                return numOfKiloMeters * 4;

            }
            catch (Exception)
            {
                return 0;
            }

        }
    }
}

