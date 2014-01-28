using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class InstituteController : Controller
    {
        //
        // GET: /Institute/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<institute> institutelist = db.institutes.ToList();
                return View(institutelist);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(institute iObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.institutes.Add(iObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var iObj = db.institutes.Find(id);
                return View(iObj);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                institute iObj = db.institutes.Where(i => i.Id == id).SingleOrDefault();
                return View(iObj);
             
            }
        }
        [HttpPost]
        public ActionResult Edit(institute iObj)
        {
            using (var db = new sadiqEntities2())
            {
                institute localIObj = db.institutes.Where(i => i.Id == iObj.Id).SingleOrDefault();
                if (localIObj != null)
                {
                    db.Entry(localIObj).CurrentValues.SetValues(iObj);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                institute iObj = db.institutes.Where(i => i.Id == id).SingleOrDefault();
                db.institutes.Remove(iObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
