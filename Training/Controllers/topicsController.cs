﻿using System;
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
    public class topicsController : Controller
    {
        private TrainingFpt db = new TrainingFpt();

        // GET: topics
        public ActionResult Index()
        {
            var topics = db.topics.Include(t => t.course);
            return View(topics.ToList());
        }

        // GET: topics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            topic topic = db.topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: topics/Create
        public ActionResult Create()
        {
            ViewBag.courseID = new SelectList(db.courses, "ID", "courseName");
            return View();
        }

        // POST: topics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,courseID,topicName,description")] topic topic)
        {
            if (ModelState.IsValid)
            {
                db.topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseID = new SelectList(db.courses, "ID", "courseName", topic.courseID);
            return View(topic);
        }

        // GET: topics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            topic topic = db.topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseID = new SelectList(db.courses, "ID", "courseName", topic.courseID);
            return View(topic);
        }

        // POST: topics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,courseID,topicName,description")] topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(topic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseID = new SelectList(db.courses, "ID", "courseName", topic.courseID);
            return View(topic);
        }

        // GET: topics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            topic topic = db.topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            topic topic = db.topics.Find(id);
            db.topics.Remove(topic);
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
