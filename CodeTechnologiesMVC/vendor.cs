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
    
    public partial class vendor
    {
        public vendor()
        {
            this.purchasingpricings = new HashSet<purchasingpricing>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<purchasingpricing> purchasingpricings { get; set; }
    }
}
