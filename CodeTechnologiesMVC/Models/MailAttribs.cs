using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeTechnologiesMVC.Models
{
    public class MailAttribs
    {
        [Required(ErrorMessage= "Received Date is Mandatory")]
        public DateTime ReceivedDate { get; set; }
        [Required(ErrorMessage = "Candidate Name is Mandatory")]
        public string CandidateName { get; set; }
        [Required(ErrorMessage = "ExamNo is Mandatory")]
        public string ExamNo { get; set; }
        public Nullable<int> Discount { get; set; }
        public Nullable<bool> Abroad { get; set; }
        public Nullable<System.DateTime> ScheduledDate { get; set; }
        [Required(ErrorMessage = "InstituteID is Mandatory")]
        public Nullable<int> InstituteId { get; set; }
        public string VoucherNo { get; set; }
        public Nullable<int> CommittedPrice { get; set; }
    
    }
}