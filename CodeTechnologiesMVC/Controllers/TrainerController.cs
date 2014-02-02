using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class TrainerController : Controller
    {
        //
        // GET: /Trainer/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                var trainersList = db.trainers.ToList();
                return View(trainersList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(trainer trainerObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.trainers.Add(trainerObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var trainerObj = db.trainers.Where(i => i.TrainerID == id).SingleOrDefault();
                return View(trainerObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(trainer trainerObj)
        {
            using (var db = new sadiqEntities2())
            {
                var localTrainerObj = db.trainers.Where(i => i.TrainerID == trainerObj.TrainerID).SingleOrDefault();
                db.Entry(localTrainerObj).CurrentValues.SetValues(trainerObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var trainerObj = db.trainers.Find(id);
                return View(trainerObj);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var trainerObj = db.trainers.Where(i => i.TrainerID == id).SingleOrDefault();
                db.trainers.Remove(trainerObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
