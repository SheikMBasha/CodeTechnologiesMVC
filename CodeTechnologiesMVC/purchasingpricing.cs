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
    
    public partial class purchasingpricing
    {
        public int Id { get; set; }
        public string VendorId { get; set; }
        public string ClientId { get; set; }
        public string VoucherType { get; set; }
        public string VoucherNature { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<int> BatchNo { get; set; }
    
        public virtual client client { get; set; }
        public virtual vendor vendor { get; set; }
    }
}
