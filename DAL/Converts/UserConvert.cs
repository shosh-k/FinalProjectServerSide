using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Converts
{
    public static class UserConvert
    {

        public static Users ConvertUserToEF(UserModel user)
        {
            return new Users
            {
                CodeUser = user.CodeUser,
                FirstNameUser = user.FirstNameUser,
                LastNameUser = user.LastNameUser,
                PasswordUser = user.PasswordUser,
                EmailUser = user.EmailUser,
                PhoneUser = user.PhoneUser,
                AddresstUser = user.AddresstUser

            };
        }
        public static UserModel ConvertUserToModel(Users user)
        {
            return new UserModel
            {
                CodeUser = user.CodeUser,
                FirstNameUser = user.FirstNameUser,
                LastNameUser = user.LastNameUser,
                PasswordUser = user.PasswordUser,
                EmailUser = user.EmailUser,
                PhoneUser = user.PhoneUser,
                AddresstUser = user.AddresstUser
            };
        }


        public static List<UserModel> ConvertUserListToModel(IEnumerable<Users> user)
        {
            return user.Select(c => ConvertUserToModel(c)).OrderBy(n => n.CodeUser).ToList();
        }
    }
}
