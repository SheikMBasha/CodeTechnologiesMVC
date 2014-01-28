using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<client> clientObj = db.GetAllClients();
                return View(clientObj);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(client clientObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.clients.Add(clientObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var clientObj = db.clients.Find(id);
                return View(clientObj);
            }
        }

        public ActionResult Delete(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var clientObj = db.clients.Where(i => String.Equals(i.Id, id)).SingleOrDefault();
                db.clients.Remove(clientObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            using (var db = new sadiqEntities2())
            {
                var clientObj = db.clients.Where(i => String.Equals(i.Id, id)).SingleOrDefault();
                return View(clientObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(client clientObj)
        {
            using (var db = new sadiqEntities2())
            {
                client localClientObj = db.clients.Where(i => String.Equals(i.Id, clientObj.Id)).SingleOrDefault();
                db.Entry(localClientObj).CurrentValues.SetValues(clientObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
