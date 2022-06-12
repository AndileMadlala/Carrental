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
    public class CarQuotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CarQuotes
        public ActionResult Index()
        {
            return View(db.Quotes.ToList());
        }

        // GET: CarQuotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarQuote carQuote = db.Quotes.Find(id);
            if (carQuote == null)
            {
                return HttpNotFound();
            }
            return View(carQuote);
        }

        // GET: CarQuotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarQuotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteId,PickUp,DropOff,PickTime,DropTime,TotalPrice,BasicPrice,NumOfDays,CarId,Basicsecuritycost,Basicdrivercost,Securitycost2,Drivercostrad,securityrad,drivercost2,bname,Carmod")] CarQuote carQuote, int id)
        {
            if (ModelState.IsValid)
            {
               
                carQuote.CarId = id;
                carQuote.NumberOfDays();
                carQuote.CalcDrivercost();
                carQuote.CalcSecuritycost();
                carQuote.getBrandname(id);
                carQuote.getCarmodel(id);
                carQuote.getdrivercost(id);
                carQuote.getSecuritycost(id); 
              
                carQuote.getBasic(id);
                carQuote.getTotalPrice(id);

                carQuote.Currentdate = DateTime.Now;
               
                db.Quotes.Add(carQuote);
                db.SaveChanges();
                return RedirectToAction("getQuotes");
            }

            return View(carQuote);
        }
        

        public ActionResult getQuotes()
        {
            return View(db.Quotes.ToList());
        }

        // GET: CarQuotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarQuote carQuote = db.Quotes.Find(id);
            if (carQuote == null)
            {
                return HttpNotFound();
            }
            return View(carQuote);
        }

        // POST: CarQuotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteId,PickUp,DropOff,PickTime,DropTime,TotalPrice,BasicPrice,NumOfDays,CarId")] CarQuote carQuote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carQuote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carQuote);
        }

        // GET: CarQuotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarQuote carQuote = db.Quotes.Find(id);
            if (carQuote == null)
            {
                return HttpNotFound();
            }
            return View(carQuote);
        }

        // POST: CarQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarQuote carQuote = db.Quotes.Find(id);
            db.Quotes.Remove(carQuote);
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
