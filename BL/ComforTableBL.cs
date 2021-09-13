using BL.Dijkstra;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ComforTableBL
    {
        public DBConnection dbCon;

        public ComforTableBL()
        {
            dbCon = new DBConnection();
        }

        //הוספה, מחיקה ועידכון
        public void AddToDB<T>(T entity) where T : class
        {
            dbCon.Execute<T>(entity, DBConnection.ExecuteActions.Insert);
        }
        public void DeleteDB<T>(T entity) where T : class
        {
            dbCon.Execute<T>(entity, DBConnection.ExecuteActions.Delete);
        }
        public void UpdateDB<T>(T entity) where T : class
        {
            dbCon.Execute<T>(entity, DBConnection.ExecuteActions.Update);
        }      

    }
}













