using CodeTechnologiesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace CodeTechnologiesMVC.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index(string SearchString, int? page)
        {
            using (var db = new sadiqEntities2())
            {
                IEnumerable<MailViewModel> mails = db.GetMailDetails();
                if (!String.IsNullOrEmpty(SearchString))
                {
                    mails = mails.Where(m => m.CandidateName.ToUpper().Contains(SearchString.ToUpper()));
                }
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(mails.ToPagedList(pageNumber, pageSize));
            }
        }

    }
}
