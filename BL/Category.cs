using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Category : ComforTableBL
    {
        //הצגת כל הערכים שבטבלה
        public List<Categories> GetCategories()
        {
            return dbCon.GetDbSet<Categories>().ToList();
        }

        //הצגת תתי הקטגוריות לפי קוד קטגוריה
        public List<SubCategories> GetSubCategory(int codeCaterory)
        {
            return dbCon.GetDbSet<SubCategories>().Where(e=> e.CodeCategorySub == codeCaterory).ToList();
        }
    }
}
