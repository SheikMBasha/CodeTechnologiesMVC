using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class PrometricController : Controller
    {
        //
        // GET: /Prometric/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                var prometriclist = db.prometrics.ToList();
                return View(prometriclist);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(prometric prometricObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.prometrics.Add(prometricObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                prometric prometricObj = db.prometrics.Find(id);
                return View(prometricObj);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                prometric prometricObj = db.prometrics.Where(i => i.SiteId == id).SingleOrDefault();
                return View(prometricObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(prometric prometricObj)
        {
            using (var db = new sadiqEntities2())
            {
                prometric localPrometricObj = db.prometrics.Where(i => i.SiteId == prometricObj.SiteId).SingleOrDefault();
                db.Entry(localPrometricObj).CurrentValues.SetValues(localPrometricObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                prometric prometricObj = db.prometrics.Where(i => i.SiteId == id).SingleOrDefault();
                db.prometrics.Remove(prometricObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
