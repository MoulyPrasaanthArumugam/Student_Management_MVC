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
    public class Hacker_RegistrationController : Controller
    {
        private LEARNINGEntities db = new LEARNINGEntities();

        // GET: Hacker_Registration
        public ActionResult Index()
        {
            var hacker_Registration = db.Hacker_Registration.Include(h => h.Hacker_Batch).Include(h => h.Hacker_Course);
            return View(hacker_Registration.ToList());
        }

        // GET: Hacker_Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Registration hacker_Registration = db.Hacker_Registration.Find(id);
            if (hacker_Registration == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Registration);
        }

        // GET: Hacker_Registration/Create
        public ActionResult Create()
        {
            ViewBag.Batch_ID = new SelectList(db.Hacker_Batch, "Batch_ID", "Name");
            ViewBag.Course_ID = new SelectList(db.Hacker_Course, "Course_ID", "Name");
            return View();
        }

        // POST: Hacker_Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Registration_ID,First_Name,Last_Name,Nic,Batch_ID,Course_ID,Tel")] Hacker_Registration hacker_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Hacker_Registration.Add(hacker_Registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch_ID = new SelectList(db.Hacker_Batch, "Batch_ID", "Name", hacker_Registration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.Hacker_Course, "Course_ID", "Name", hacker_Registration.Course_ID);
            return View(hacker_Registration);
        }

        // GET: Hacker_Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Registration hacker_Registration = db.Hacker_Registration.Find(id);
            if (hacker_Registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch_ID = new SelectList(db.Hacker_Batch, "Batch_ID", "Name", hacker_Registration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.Hacker_Course, "Course_ID", "Name", hacker_Registration.Course_ID);
            return View(hacker_Registration);
        }

        // POST: Hacker_Registration/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Registration_ID,First_Name,Last_Name,Nic,Batch_ID,Course_ID,Tel")] Hacker_Registration hacker_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hacker_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch_ID = new SelectList(db.Hacker_Batch, "Batch_ID", "Name", hacker_Registration.Batch_ID);
            ViewBag.Course_ID = new SelectList(db.Hacker_Course, "Course_ID", "Name", hacker_Registration.Course_ID);
            return View(hacker_Registration);
        }

        // GET: Hacker_Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Registration hacker_Registration = db.Hacker_Registration.Find(id);
            if (hacker_Registration == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Registration);
        }

        // POST: Hacker_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hacker_Registration hacker_Registration = db.Hacker_Registration.Find(id);
            db.Hacker_Registration.Remove(hacker_Registration);
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
