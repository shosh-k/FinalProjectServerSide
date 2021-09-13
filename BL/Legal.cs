using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DAL;

namespace BL
{
    public class Legal
    {
        Regex reg;
        //בדיקת תעודת זהות 
        public static bool CheckLegalId(string s)
        {
            int x;
            if (!int.TryParse(s, out x))
                return false;
            if (s.Length < 5 || s.Length > 9)
                return false;
            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;

            }
            return sum % 10 == 0;
        }

        //אותיות בלבד
        public bool CheckLegalLetters(string word)
        {
            reg = new Regex(@"\b[א-ת-\s ]+$");
            return reg.IsMatch(word);

        }
        //טלפון
        public bool CheckLegalTelephone(string tel)
        {
            reg = new Regex(@"\b0[ 2 4 7 8 3 77]-[2-9]\d{6}$");
            return reg.IsMatch(tel);
        }

        //פלאפון
        public bool CheckLegalCellPhone(string tel)
        {
            reg = new Regex(@"\b05[0 2 4 5 6 7 8 3]-[2-9]\d{6}$");
            return reg.IsMatch(tel);
        }
        //סיסמא
        public static bool IsPassword(string pass, string id)
        {
            DBConnection db = new DBConnection();
            if (pass.Length < 6)
                return false;
            if (pass.Contains(id))
                return false;
            if (db.GetDbSet<Users>().First(c => c.PasswordUser == pass) != null)
                return false;
            return LettersAndNumbers(pass);
        }

        //חישוב גיל לפי תאריך לידה
        public int GetAge(DateTime d)
        {
            DateTime t = DateTime.Today;
            int age = t.Year - d.Year;
            if (t < d.AddYears(age)) age--;
            return age;
        }
        //מייל
        public static bool CheackMail(string t)
        {
            if (!t.Contains("@gmail."))
                return false;
            Regex regex1 = new Regex("@gmail");
            string[] strSplit = regex1.Split(t);
            Regex regex2 = new Regex(".com|.co.il");
            bool check1 = regex2.IsMatch(strSplit[1]);
            Regex regex3 = new Regex("^[a-zA-Z0-9._]*$");
            bool check2 = regex3.IsMatch(strSplit[0]);
            if (check2 && check1)
                return true;
            return false;
        }
        //מספרים בלבד
        public bool CheckLegalNumber(string num)
        {
            reg = new Regex(@"\b[0-9-\s]+$");
            return reg.IsMatch(num);
        }
        //מספרים ואותיות
        public static bool LettersAndNumbers(string add)
        {
            Regex regex3 = new Regex("[0-9]");
            Regex regex4 = new Regex("[a-zA-Zא-ת]");
            return regex3.IsMatch(add) && regex4.IsMatch(add);
        }
    }
}
