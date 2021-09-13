using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        public int CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public Nullable<int> CategoryProduct { get; set; }
        public Nullable<int> SubCategoryProduct { get; set; }
        public Nullable<int> CodeSallerProduct { get; set; }
        public Nullable<double> PriceProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public Nullable<int> StatusProduct { get; set; }
        public Nullable<int> MoveOrBuy { get; set; }
        public Nullable<int> NewOrOld { get; set; }
        public Nullable<int> ProductSold { get; set; }

    }
}
