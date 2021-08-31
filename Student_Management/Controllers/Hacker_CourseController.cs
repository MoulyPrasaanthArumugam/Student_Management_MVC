using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Management.Models;

namespace Student_Management.Controllers
{
    public class Hacker_CourseController : Controller
    {
        private LEARNINGEntities db = new LEARNINGEntities();

        // GET: Hacker_Course
        public ActionResult Index()
        {
            return View(db.Hacker_Course.ToList());
        }

        // GET: Hacker_Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Course hacker_Course = db.Hacker_Course.Find(id);
            if (hacker_Course == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Course);
        }

        // GET: Hacker_Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hacker_Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_ID,Name,Duration")] Hacker_Course hacker_Course)
        {
            if (ModelState.IsValid)
            {
                db.Hacker_Course.Add(hacker_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hacker_Course);
        }

        // GET: Hacker_Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Course hacker_Course = db.Hacker_Course.Find(id);
            if (hacker_Course == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Course);
        }

        // POST: Hacker_Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_ID,Name,Duration")] Hacker_Course hacker_Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hacker_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hacker_Course);
        }

        // GET: Hacker_Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Course hacker_Course = db.Hacker_Course.Find(id);
            if (hacker_Course == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Course);
        }

        // POST: Hacker_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hacker_Course hacker_Course = db.Hacker_Course.Find(id);
            db.Hacker_Course.Remove(hacker_Course);
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
