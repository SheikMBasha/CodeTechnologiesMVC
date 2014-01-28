using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class AcademyController : Controller
    {
        //
        // GET: /Academy/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<academy> academyObj = db.academies.ToList();
                return View(academyObj);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(academy academyObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.academies.Add(academyObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var aObj = db.academies.Find(id);
                return View(aObj);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var aObj = db.academies.Where(i => i.Id == id).SingleOrDefault();
                return View(aObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(academy academyObj)
        {
            using (var db = new sadiqEntities2())
            {
                academy localAcademyObj = db.academies.Where(i => i.Id == academyObj.Id).SingleOrDefault();
                db.Entry(localAcademyObj).CurrentValues.SetValues(academyObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                academy academyObj = db.academies.Where(i => i.Id == id).SingleOrDefault();
                db.academies.Remove(academyObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
        }

    }
}
