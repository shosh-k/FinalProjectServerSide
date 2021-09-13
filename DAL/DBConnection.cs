using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBConnection
    {
        public DBConnection()
        {
        }

        //הצגת טבלאות
        public List<T> GetDbSet<T>() where T : class
        {
            using (ComforTableEntities a = new ComforTableEntities())
            {
                return a.Set<T>().ToList();
            }
        }

        //הוספה, עידכון ומחיקה
        public enum ExecuteActions
        {
            Insert,
            Update,
            Delete
        }
        public void Execute<T>(T entity, ExecuteActions exAction) where T : class
        {
            using (ComforTableEntities a = new ComforTableEntities())
            {
                var model = a.Set<T>();
                switch (exAction)
                {
                    case ExecuteActions.Insert:
                        model.Add(entity);
                        break;
                    case ExecuteActions.Update:
                        model.Attach(entity);
                        a.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        break;
                    case ExecuteActions.Delete:
                        model.Attach(entity);
                        a.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                        break;
                    default:
                        break;
                }
                a.SaveChanges();
            }
        }
    }
}
