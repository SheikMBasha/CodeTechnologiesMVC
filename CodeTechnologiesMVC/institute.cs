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
    
    public partial class institute
    {
        public institute()
        {
            this.candidates = new HashSet<candidate>();
            this.mails = new HashSet<mail>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string POCName { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    
        public virtual ICollection<candidate> candidates { get; set; }
        public virtual ICollection<mail> mails { get; set; }
    }
}