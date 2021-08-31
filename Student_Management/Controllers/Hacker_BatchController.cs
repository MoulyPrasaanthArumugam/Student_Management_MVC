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
    public class Hacker_BatchController : Controller
    {
        private LEARNINGEntities db = new LEARNINGEntities();

        // GET: Hacker_Batch
        public ActionResult Index()
        {
            return View(db.Hacker_Batch.ToList());
        }

        // GET: Hacker_Batch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Batch hacker_Batch = db.Hacker_Batch.Find(id);
            if (hacker_Batch == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Batch);
        }

        // GET: Hacker_Batch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hacker_Batch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Batch_ID,Name,Year")] Hacker_Batch hacker_Batch)
        {
            if (ModelState.IsValid)
            {
                db.Hacker_Batch.Add(hacker_Batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hacker_Batch);
        }

        // GET: Hacker_Batch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Batch hacker_Batch = db.Hacker_Batch.Find(id);
            if (hacker_Batch == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Batch);
        }

        // POST: Hacker_Batch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Batch_ID,Name,Year")] Hacker_Batch hacker_Batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hacker_Batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hacker_Batch);
        }

        // GET: Hacker_Batch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_Batch hacker_Batch = db.Hacker_Batch.Find(id);
            if (hacker_Batch == null)
            {
                return HttpNotFound();
            }
            return View(hacker_Batch);
        }

        // POST: Hacker_Batch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hacker_Batch hacker_Batch = db.Hacker_Batch.Find(id);
            db.Hacker_Batch.Remove(hacker_Batch);
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
