using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using carrentalservice.Models;

namespace carrentalservice.Controllers
{
    public class GetQuote1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GetQuote1
        public ActionResult Index()
        {
            return View(db.GetQuote1.ToList());
        }

        // GET: GetQuote1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetQuote1 getQuote1 = db.GetQuote1.Find(id);
            if (getQuote1 == null)
            {
                return HttpNotFound();
            }
            return View(getQuote1);
        }

        // GET: GetQuote1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GetQuote1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,Car1,car2")] GetQuote1 getQuote1)
        {
            if (ModelState.IsValid)
            {
                db.GetQuote1.Add(getQuote1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(getQuote1);
        }

        // GET: GetQuote1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetQuote1 getQuote1 = db.GetQuote1.Find(id);
            if (getQuote1 == null)
            {
                return HttpNotFound();
            }
            return View(getQuote1);
        }

        // POST: GetQuote1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,Car1,car2")] GetQuote1 getQuote1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(getQuote1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(getQuote1);
        }

        // GET: GetQuote1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GetQuote1 getQuote1 = db.GetQuote1.Find(id);
            if (getQuote1 == null)
            {
                return HttpNotFound();
            }
            return View(getQuote1);
        }

        // POST: GetQuote1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GetQuote1 getQuote1 = db.GetQuote1.Find(id);
            db.GetQuote1.Remove(getQuote1);
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
