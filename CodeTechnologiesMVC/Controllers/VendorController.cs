using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class VendorController : Controller
    {
        //
        // GET: /Vendor/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                var vendorsList = db.vendors.ToList();
                return View(vendorsList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(vendor vendorObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.vendors.Add(vendorObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var vendorObj = db.vendors.Find(id);
                return View(vendorObj);
            }
        }

        public ActionResult Edit(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var vendorObj = db.vendors.Where(i => String.Equals(i.Id,id)).SingleOrDefault();
                return View(vendorObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(vendor vendorObj)
        {
            using (var db = new sadiqEntities2())
            {
                var localVendorObj = db.vendors.Where(i => String.Equals(i.Id, vendorObj.Id)).SingleOrDefault();
                db.Entry(localVendorObj).CurrentValues.SetValues(vendorObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var vendorObj = db.vendors.Where(i => string.Equals(i.Id, id)).SingleOrDefault();
                db.vendors.Remove(vendorObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
