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
    public class trainersController : Controller
    {
        private TrainingFpt db = new TrainingFpt();

        // GET: trainers
        public ActionResult Index()
        {
            var trainers = db.trainers.Include(t => t.account);
            return View(trainers.ToList());
        }

        // GET: trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainer trainer = db.trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: trainers/Create
        public ActionResult Create()
        {
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username");
            return View();
        }

        // POST: trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,accountID,name,type,education,workingPlace,phoneNumber,email")] trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainer.accountID);
            return View(trainer);
        }

        // GET: trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainer trainer = db.trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainer.accountID);
            return View(trainer);
        }

        // POST: trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,accountID,name,type,education,workingPlace,phoneNumber,email")] trainer trainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainer.accountID);
            return View(trainer);
        }

        // GET: trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainer trainer = db.trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainer trainer = db.trainers.Find(id);
            db.trainers.Remove(trainer);
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
