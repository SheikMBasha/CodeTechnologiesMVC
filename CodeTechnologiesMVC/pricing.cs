//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CodeTechnologiesMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class pricing
    {
        public int id { get; set; }
        public Nullable<int> InstituteId { get; set; }
        public string ClientId { get; set; }
        public string VoucherType { get; set; }
        public string VoucherNature { get; set; }
        public string Price { get; set; }
        public Nullable<bool> IsWithoutVoucher { get; set; }
        public Nullable<System.DateTime> PriceDate { get; set; }
    
        public virtual client client { get; set; }
        public virtual institute institute { get; set; }
    }
}