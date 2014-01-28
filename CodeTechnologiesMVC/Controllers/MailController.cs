using CodeTechnologiesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<MailViewModel> mailviewmodels = db.GetMailDetails();
                return View(mailviewmodels);
            }
        }

    }
}
