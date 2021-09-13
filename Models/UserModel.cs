using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        public int CodeUser { get; set; }
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public string PasswordUser { get; set; }
        public string EmailUser { get; set; }
        public string PhoneUser { get; set; }
        public Nullable<int> CityUser { get; set; }
        public string AddresstUser { get; set; }
    }
}
