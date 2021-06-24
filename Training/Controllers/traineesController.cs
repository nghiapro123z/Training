using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training.Models.Training;

namespace Training.Controllers
{
    public class traineesController : Controller
    {
        private TrainingFpt db = new TrainingFpt();

        // GET: trainees
        public ActionResult Index()
        {
            var trainees = db.trainees.Include(t => t.account);
            return View(trainees.ToList());
        }

        // GET: trainees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainee trainee = db.trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: trainees/Create
        public ActionResult Create()
        {
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username");
            return View();
        }

        // POST: trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,accountID,name,DOB,education,programmingLanguage,TOEICScore")] trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainee.accountID);
            return View(trainee);
        }

        // GET: trainees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainee trainee = db.trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainee.accountID);
            return View(trainee);
        }

        // POST: trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,accountID,name,DOB,education,programmingLanguage,TOEICScore")] trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainee.accountID);
            return View(trainee);
        }

        // GET: trainees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainee trainee = db.trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainee trainee = db.trainees.Find(id);
            db.trainees.Remove(trainee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
