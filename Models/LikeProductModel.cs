using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LikeProductModel
    {
        public int CodeLikeProduct { get; set; }
        public Nullable<int> CodeProduct { get; set; }
        public Nullable<int> CodeUser { get; set; }
    }
}
