using DAL;
using Models;
using System;
using System.Linq;
using static BL.ComforTableBL;
using static DAL.DBConnection;

namespace BL
{
    public class User : ComforTableBL
    {

        public User(){
        }
        
        //מביא משתמש לפי פלפון
        public Users GetUserByPhone(string phone)
        {
            var set = dbCon.GetDbSet<Users>();
            if (set.Any(u => u.PhoneUser == phone))
                return set.First(u => u.PhoneUser == phone);
            return null;

        }
        //מביא משתמש לפי מספר מזהה
        public Users GetUserById(int codeUser)
        {
            var set = dbCon.GetDbSet<Users>();
            if (set.Any(u => u.CodeUser == codeUser))
                return set.First(u => u.CodeUser == codeUser);
            return null;

        }

        //פונקציה שמחזירה את כתובת של מוכר
        public string GetAdress(int userId)
        {
            return GetUserById(userId).AddresstUser;
        }

        //sign up function
        public int SignUP(UserModel user)
        {
            try
            {
                //check if customer exist in DB
                if (GetUserByPhone(user.PhoneUser) == null)
                {
                    //if not exist
                    AddToDB<Users>(DAL.Converts.UserConvert.ConvertUserToEF(user));
                    //dbCon.Execute(user, ExecuteActions.Insert);
                }
                return dbCon.GetDbSet<Users>().ToList().Find(a => a.PhoneUser == user.PhoneUser).CodeUser;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        //sign in function
        public int SignIn(string phone, string password)
        {
            //check if in db
            var user = GetUserByPhone(phone);
            if (user == null)
            {
                //if not
                return 0;
            }
            //if yes and password correct
            if (user.PasswordUser == password)
            {
                //load the page with his details and return CorrectPass
                return user.CodeUser;
            }
            //if the password isn't correct
            return 0;
        }
    }
}





