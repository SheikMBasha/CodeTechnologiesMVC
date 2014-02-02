using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class SellingPriceController : Controller
    {
        private sadiqEntities2 db = new sadiqEntities2();

        //
        // GET: /SellingPrice/

        public ActionResult Index()
        {
            var pricings = db.pricings.Include(p => p.client).Include(p => p.institute);
            return View(pricings.ToList());
        }

        //
        // GET: /SellingPrice/Details/5

        public ActionResult Details(int id = 0)
        {
            pricing pricing = db.pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        //
        // GET: /SellingPrice/Create

        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name");
            ViewBag.InstituteId = new SelectList(db.institutes, "Id", "Name");
            return View();
        }

        //
        // POST: /SellingPrice/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(pricing pricing)
        {
            if (ModelState.IsValid)
            {
                db.pricings.Add(pricing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", pricing.ClientId);
            ViewBag.InstituteId = new SelectList(db.institutes, "Id", "Name", pricing.InstituteId);
            return View(pricing);
        }

        //
        // GET: /SellingPrice/Edit/5

        public ActionResult Edit(int id = 0)
        {
            pricing pricing = db.pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", pricing.ClientId);
            ViewBag.InstituteId = new SelectList(db.institutes, "Id", "Name", pricing.InstituteId);
            return View(pricing);
        }

        //
        // POST: /SellingPrice/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(pricing pricing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pricing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.clients, "Id", "Name", pricing.ClientId);
            ViewBag.InstituteId = new SelectList(db.institutes, "Id", "Name", pricing.InstituteId);
            return View(pricing);
        }

        //
        // GET: /SellingPrice/Delete/5

        public ActionResult Delete(int id = 0)
        {
            pricing pricing = db.pricings.Find(id);
            if (pricing == null)
            {
                return HttpNotFound();
            }
            return View(pricing);
        }

        //
        // POST: /SellingPrice/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pricing pricing = db.pricings.Find(id);
            db.pricings.Remove(pricing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}