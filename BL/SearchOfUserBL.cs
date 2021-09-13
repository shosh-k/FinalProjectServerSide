using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SearchOfUserBL:ComforTableBL
    {
        public SearchOfUserBL()
        {

        }

        public SearchOfUser GetSearchByCodeUser(int codeUser)
        {
            dbCon.GetDbSet<SearchOfUser>().First();
            var set = dbCon.GetDbSet<SearchOfUser>();
            if (set.Any(u => u.CodeUser == codeUser))
                return set.First(u => u.CodeUser == codeUser);
            return null;
        }
        public void AddSearch(SearchOfUser search)
        {
            if (GetSearchByCodeUser(int.Parse(search.CodeUser.ToString())) == null)
            {
                AddToDB<SearchOfUser>(search);
            }
            else
                UpdateDB<SearchOfUser>(search);
        }
    }
}
