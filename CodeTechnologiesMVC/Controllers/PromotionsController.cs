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

        public ActionResult IndexWithId(int? siteID)
        {
            using (var db = new sadiqEntities2())
            {
                List<prometricpromotion> prometricPromotionList = db.prometricpromotions.Where(i => i.SiteId == siteID).ToList();
                ViewBag.siteId = siteID;
                ViewBag.PromotionExists = prometricPromotionList.Count;
                if (db.prometrics.Find(siteID).IsHired == true)
                {
                    return RedirectToAction("CustomerPrometricError");
                }
                else
                {
                    return View(prometricPromotionList);
                }
            }
        }

        public ActionResult Create(int id)
        {
            ViewBag.passedSiteId = id;
            return View();
        }

        public ActionResult CustomerPrometricError()
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
                return RedirectToAction("IndexWithId", new { siteID = ppObj.SiteId });
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
                return RedirectToAction("IndexWithId", new { siteID = ppObj.SiteId });
            }
        }

        public ActionResult Delete(int id, int? siteId)
        {
            using (var db = new sadiqEntities2())
            {
                prometricpromotion ppObj = db.prometricpromotions.Where(i => i.id == id).SingleOrDefault();
                db.prometricpromotions.Remove(ppObj);
                db.SaveChanges();
                return RedirectToAction("IndexWithId", new { siteID = siteId });
            }
        }

    }
}
