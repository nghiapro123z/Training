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
    public class trainingStaffsController : Controller
    {
        private TrainingFpt db = new TrainingFpt();

        // GET: trainingStaffs
        public ActionResult Index()
        {
            var trainingStaffs = db.trainingStaffs.Include(t => t.account);
            return View(trainingStaffs.ToList());
        }

        // GET: trainingStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingStaff trainingStaff = db.trainingStaffs.Find(id);
            if (trainingStaff == null)
            {
                return HttpNotFound();
            }
            return View(trainingStaff);
        }

        // GET: trainingStaffs/Create
        public ActionResult Create()
        {
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username");
            return View();
        }

        // POST: trainingStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,accountID,name,DOB,phoneNumber,email")] trainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                db.trainingStaffs.Add(trainingStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainingStaff.accountID);
            return View(trainingStaff);
        }

        // GET: trainingStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingStaff trainingStaff = db.trainingStaffs.Find(id);
            if (trainingStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainingStaff.accountID);
            return View(trainingStaff);
        }

        // POST: trainingStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,accountID,name,DOB,phoneNumber,email")] trainingStaff trainingStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountID = new SelectList(db.accounts, "ID", "username", trainingStaff.accountID);
            return View(trainingStaff);
        }

        // GET: trainingStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trainingStaff trainingStaff = db.trainingStaffs.Find(id);
            if (trainingStaff == null)
            {
                return HttpNotFound();
            }
            return View(trainingStaff);
        }

        // POST: trainingStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trainingStaff trainingStaff = db.trainingStaffs.Find(id);
            db.trainingStaffs.Remove(trainingStaff);
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
