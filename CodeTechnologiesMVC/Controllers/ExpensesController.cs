using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeTechnologiesMVC.Controllers
{
    public class ExpensesController : Controller
    {
        //
        // GET: /Expenses/

        public ActionResult Index()
        {
            using (var db = new sadiqEntities2())
            {
                List<expens> expensesList = db.expenses.ToList();
                return View(expensesList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(expens expenseObj)
        {
            using (var db = new sadiqEntities2())
            {
                db.expenses.Add(expenseObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new sadiqEntities2())
            {
                expens expenseObj = db.expenses.Find(id);
                return View(expenseObj);
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new sadiqEntities2())
            {
                expens expenseObj = db.expenses.Where(i => i.Id == id).SingleOrDefault();
                return View(expenseObj);
            }
        }

        [HttpPost]
        public ActionResult Edit(expens expenseObj)
        {
            using (var db = new sadiqEntities2())
            {
                var localExpenseObj = db.expenses.Where(i => i.Id == expenseObj.Id).SingleOrDefault();
                db.Entry(localExpenseObj).CurrentValues.SetValues(expenseObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new sadiqEntities2())
            {
                var expenseObj = db.expenses.Where(i => i.Id == id).SingleOrDefault();
                db.expenses.Remove(expenseObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
