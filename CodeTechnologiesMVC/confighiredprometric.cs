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
    
    public partial class confighiredprometric
    {
        public int id { get; set; }
        public int PrometricSiteId { get; set; }
        public int ProfitMargin { get; set; }
    
        public virtual prometric prometric { get; set; }
    }
}
