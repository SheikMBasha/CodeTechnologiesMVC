using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class CodeController : Controller
    {
        //
        // GET: /Code/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<examcode> codelist = db.examcodes.ToList();
                return View(codelist);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(examcode codeObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.examcodes.Add(codeObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var codeObj = db.examcodes.Find(id);
                return View(codeObj);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var codeObj = db.examcodes.Where(i => i.Id == id).SingleOrDefault();
                return View(codeObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(examcode codeObj)
        {
            using (var db = new sadiqEntities2())
            {
                var localCodeObj = db.examcodes.Where(i => i.Id == codeObj.Id).SingleOrDefault();
                db.Entry(localCodeObj).CurrentValues.SetValues(codeObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var codeObj = db.examcodes.Where(i => i.Id == id).SingleOrDefault();
                db.examcodes.Remove(codeObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
