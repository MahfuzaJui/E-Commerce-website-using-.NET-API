//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Carts = new HashSet<Cart>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string PropertyType { get; set; }
        public Nullable<int> Bed { get; set; }
        public Nullable<int> Bath { get; set; }
        public Nullable<double> Size { get; set; }
    
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
