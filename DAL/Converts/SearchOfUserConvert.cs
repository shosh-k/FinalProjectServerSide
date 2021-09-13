using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static  class SearchOfUserConvert
    {

        public static SearchOfUser ConvertSearchOfUserToEF(SearchOfUserModel searchOfUser)
        {
            return new SearchOfUser
            {
                CodeSearchOfUser = searchOfUser.CodeSearchOfUser,
                searchPath = searchOfUser.searchPath,
                CodeUser = searchOfUser.CodeUser,
            };

        }
        public static SearchOfUserModel ConvertSearchOfUserToModel(SearchOfUser searchOfUser)
        {
            return new SearchOfUserModel
            {
                CodeSearchOfUser = searchOfUser.CodeSearchOfUser,
                searchPath = searchOfUser.searchPath,
                CodeUser = searchOfUser.CodeUser,
            };
        }

        public static List<SearchOfUserModel> ConvertSearchOfUserListToModel(IEnumerable<SearchOfUser> searchOfUser)
        {
            return searchOfUser.Select(c => ConvertSearchOfUserToModel(c)).OrderBy(n => n.CodeSearchOfUser).ToList();
        }
    }
}
