using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using carrentalservice.Models;
using carrentalservice.Views.drivers;

namespace carrentalservice.Controllers
{
    public class driverQuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: driverQuotes
        public ActionResult Index()
        {
            return View(db.driverQuotes.ToList());
        }

        // GET: driverQuotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driverQuote driverQuote = db.driverQuotes.Find(id);
            if (driverQuote == null)
            {
                return HttpNotFound();
            }
            return View(driverQuote);
        }

        // GET: driverQuotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: driverQuotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriveID,droploc,pickuploc,DriverID")] driverQuote driverQuote, int id2)
        {
            driverQuote.DriverID = id2;
            if (ModelState.IsValid)
            {
                db.driverQuotes.Add(driverQuote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverQuote);
        }
        public ActionResult driveQuote ()
        {
            return View(db.Quotes.ToList());
        }

        // GET: driverQuotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driverQuote driverQuote = db.driverQuotes.Find(id);
            if (driverQuote == null)
            {
                return HttpNotFound();
            }
            return View(driverQuote);
        }

        // POST: driverQuotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriveID,droploc,pickuploc,DriverID")] driverQuote driverQuote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverQuote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverQuote);
        }

        // GET: driverQuotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driverQuote driverQuote = db.driverQuotes.Find(id);
            if (driverQuote == null)
            {
                return HttpNotFound();
            }
            return View(driverQuote);
        }

        // POST: driverQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            driverQuote driverQuote = db.driverQuotes.Find(id);
            db.driverQuotes.Remove(driverQuote);
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
