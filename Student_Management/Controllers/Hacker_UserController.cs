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
    public class Hacker_UserController : Controller
    {
        private LEARNINGEntities db = new LEARNINGEntities();

        // GET: Hacker_User
        public ActionResult Index()
        {
            return View(db.Hacker_User.ToList());
        }

        // GET: Hacker_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_User hacker_User = db.Hacker_User.Find(id);
            if (hacker_User == null)
            {
                return HttpNotFound();
            }
            return View(hacker_User);
        }

        // GET: Hacker_User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hacker_User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_ID,First_Name,Last_Name,User_Name,Password")] Hacker_User hacker_User)
        {
            if (ModelState.IsValid)
            {
                db.Hacker_User.Add(hacker_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hacker_User);
        }

        // GET: Hacker_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_User hacker_User = db.Hacker_User.Find(id);
            if (hacker_User == null)
            {
                return HttpNotFound();
            }
            return View(hacker_User);
        }

        // POST: Hacker_User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_ID,First_Name,Last_Name,User_Name,Password")] Hacker_User hacker_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hacker_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hacker_User);
        }

        // GET: Hacker_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hacker_User hacker_User = db.Hacker_User.Find(id);
            if (hacker_User == null)
            {
                return HttpNotFound();
            }
            return View(hacker_User);
        }

        // POST: Hacker_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hacker_User hacker_User = db.Hacker_User.Find(id);
            db.Hacker_User.Remove(hacker_User);
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
