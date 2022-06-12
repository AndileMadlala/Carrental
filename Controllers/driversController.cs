using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using carrentalservice.Models;

namespace carrentalservice.Controllers
{
    public class driversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: drivers
        public ActionResult Index()
        {
            return View(db.drivers.ToList());
        }

        // GET: drivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driver driver = db.drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // GET: drivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: drivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverID,Drivername,costPerKilo,Image2,ImageType2")] driver driver, HttpPostedFileBase file2)
        {
            if (file2 != null && file2.ContentLength > 0)
            {
                driver.ImageType2 = Path.GetExtension(file2.FileName);
                driver.Image2 = ConvertToBytes2(file2);
            }
            if (ModelState.IsValid)
            {
                db.drivers.Add(driver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driver);
        }
        public byte[] ConvertToBytes2(HttpPostedFileBase file2)
        {
            BinaryReader reader2 = new BinaryReader(file2.InputStream);
            return reader2.ReadBytes((int)file2.ContentLength);
        }

        public FileStreamResult RenderImage2(int id2)
        {
            MemoryStream ms1 = null;

            var item2 = db.drivers.FirstOrDefault(p => p.DriverID == id2);
            if (item2 != null)
            {
                ms1 = new MemoryStream(item2.Image2);
            }
            return new FileStreamResult(ms1, item2.ImageType2);
        }
        public ActionResult DriverAvail()
        {
            return View(db.drivers.ToList());
        }


        // GET: drivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driver driver = db.drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: drivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverID,Drivername,costPerKilo,Image2,ImageType2")] driver driver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver);
        }

        // GET: drivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            driver driver = db.drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            driver driver = db.drivers.Find(id);
            db.drivers.Remove(driver);
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
