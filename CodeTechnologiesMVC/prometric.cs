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
    
    public partial class prometric
    {
        public prometric()
        {
            this.confighiredprometrics = new HashSet<confighiredprometric>();
            this.expenses = new HashSet<expens>();
            this.prometricpromotions = new HashSet<prometricpromotion>();
        }
    
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string POCName { get; set; }
        public int POCPhone { get; set; }
        public string POCEmail { get; set; }
        public string SiteAddress { get; set; }
        public Nullable<bool> IsHired { get; set; }
        public string PerExamProfit { get; set; }
        public Nullable<int> TCAAdminId { get; set; }
        public string SiteOwnerName { get; set; }
    
        public virtual ICollection<confighiredprometric> confighiredprometrics { get; set; }
        public virtual ICollection<expens> expenses { get; set; }
        public virtual techcentreadmin techcentreadmin { get; set; }
        public virtual ICollection<prometricpromotion> prometricpromotions { get; set; }
    }
}
