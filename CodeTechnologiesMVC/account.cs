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
    
    public partial class account
    {
        public int Id { get; set; }
        public Nullable<int> InstituteId { get; set; }
        public Nullable<int> SiteId { get; set; }
        public Nullable<System.DateTime> DateOfDeposit { get; set; }
        public Nullable<int> AmountDebited { get; set; }
        public Nullable<int> AmountCredited { get; set; }
        public string VoucherId { get; set; }
        public string CandidateId { get; set; }
    
        public virtual institute institute { get; set; }
    }
}
