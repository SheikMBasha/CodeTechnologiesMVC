using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeTechnologiesMVC
{
    [MetadataType(typeof(PricingMetaData))]
    public partial class pricing
    {
    }

    public class PricingMetaData
    {
        [Required(ErrorMessage = "Institute Id is required!!")]
        public Nullable<int> InstituteId { get; set; }
        [Required(ErrorMessage="Client Id is required!!")]
        public string ClientId { get; set; }
        [Required(ErrorMessage="Voucher Type Required")]
        public string VoucherType { get; set; }
    }
}