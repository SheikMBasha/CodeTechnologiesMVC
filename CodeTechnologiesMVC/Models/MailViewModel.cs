using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeTechnologiesMVC.Models
{
    [Serializable]
    public class MailViewModel
    {
        public DateTime ReceivedDate { get; set; }
        public string CandidateName { get; set; }
        public int ExamNo { get; set; }
        public int Discount { get; set; }
        public string Abroad { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string Name { get; set; }
        public string VoucherNo { get; set; }
        public string Client { get; set; }
    }
}