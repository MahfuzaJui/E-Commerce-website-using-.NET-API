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
    
    public partial class For_Sell
    {
        public int Id { get; set; }
        public Nullable<int> Product_Id { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<System.DateTime> AvailableFrom { get; set; }
    }
}