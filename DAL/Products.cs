//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.Imajes = new HashSet<Imajes>();
            this.LikeProducts = new HashSet<LikeProducts>();
            this.ShoppingCast = new HashSet<ShoppingCast>();
        }
    
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
    
        public virtual Categories Categories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imajes> Imajes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LikeProducts> LikeProducts { get; set; }
        public virtual Users Users { get; set; }
        public virtual SubCategories SubCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCast> ShoppingCast { get; set; }
    }
}
