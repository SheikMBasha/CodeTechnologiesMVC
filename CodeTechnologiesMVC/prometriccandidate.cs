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
    
    public partial class prometriccandidate
    {
        public int ID { get; set; }
        public string CiscoClientId { get; set; }
        public Nullable<int> ConnectionId { get; set; }
        public string VoucherId { get; set; }
    
        public virtual voucher voucher { get; set; }
    }
}
