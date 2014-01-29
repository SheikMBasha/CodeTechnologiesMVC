using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class PromotionsController : Controller
    {
        //
        // GET: /Promotions/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<prometricpromotion> prometricPromotionList = db.prometricpromotions.ToList();
                return View(prometricPromotionList);    
            }
        }

        public ActionResult IndexWithId(int id)
        {
            using (var db = new sadiqEntities2())
            {
                List<prometricpromotion> prometricPromotionList = db.prometricpromotions.Where(i => i.SiteId == id).ToList();
                return View(prometricPromotionList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(prometricpromotion ppObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.prometricpromotions.Add(ppObj);
                db.SaveChanges();
                return View("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                prometricpromotion ppObj = db.prometricpromotions.Find(id);
                return View(ppObj);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                prometricpromotion ppObj = db.prometricpromotions.Find(id);
                return View(ppObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(prometricpromotion ppObj)
        {
            using (var db = new sadiqEntities2())
            {
                prometricpromotion localObj = db.prometricpromotions.Where(i => i.id == ppObj.id).SingleOrDefault();
                db.Entry(localObj).CurrentValues.SetValues(ppObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                prometricpromotion ppObj = db.prometricpromotions.Where(i => i.id == id).SingleOrDefault();
                db.prometricpromotions.Remove(ppObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
