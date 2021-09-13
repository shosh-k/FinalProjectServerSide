using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LocationBase
    {
        public class RootLocationBase
        {
            public Result[] results { get; set; }
        }

        public class Result
        {
            public string place_id { get; set; }
        }
    }
}
