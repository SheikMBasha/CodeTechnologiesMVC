using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class ExamsController : Controller
    {
        //
        // GET: /Exams/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<exam> examlist = db.exams.ToList();
                return View(examlist);
            }
        }

        public ActionResult Create()
        {
            IList<SelectListItem> clientsListItem = new List<SelectListItem>();
            var clients = GetClientList();
            foreach (client c in clients)
            {
                clientsListItem.Add(new SelectListItem() { Text = c.Id, Value = c.Name });
            }
            ViewBag.ClientIDs = new SelectList(clientsListItem, "Id", "Name");
            return View();
        }

        public List<client> GetClientList()
        {
            using (var db = new sadiqEntities2())
            {
                return db.clients.ToList();
            }
        }

        [HttpPost]
        public ActionResult Create(exam examObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.exams.Add(examObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string id)
        {
            using (var db = new sadiqEntities2())
            {
                exam examObj = db.exams.Find(id);
                return View(examObj);
            }
        }

        public ActionResult Edit(string id)
        {
            using (var db = new sadiqEntities2())
            {
                exam examObj = db.exams.Where(i => String.Equals(i.Id,id)).SingleOrDefault();
                return View(examObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(exam examObj)
        {
            using (var db = new sadiqEntities2())
            {
                var localExamObj = db.exams.Where(i => string.Equals(i.Id, examObj.Id)).SingleOrDefault();
                db.Entry(localExamObj).CurrentValues.SetValues(examObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var examObj = db.exams.Where(i => String.Equals(i.Id, id)).SingleOrDefault();
                db.exams.Remove(examObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
