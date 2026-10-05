using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Controllers
{
    public class RentalRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rent/RentalRequests
        public ActionResult Index()
        {
            // code to sort rental requests (sorted by start date in ascending order)             
            // 1.  create a list<T>
            var sortedRequests = db.RentalRequests.ToList();

            // 2. Iterate through the model and sort(startdate ascending order)
            sortedRequests.Sort((x, y) => DateTime.Compare(y.StartTime, x.StartTime));
            // 3. update expiration status
            foreach (var item in sortedRequests)
            {
                // A week after its last date, a rental request is considered to have expired.  
                if (item.EndTime < DateTime.Now)
                {
                    // Calculating time difference
                    double daysExpired = Convert.ToDouble((DateTime.Now - item.EndTime).TotalDays);
                    if (daysExpired >= 7.00)
                    {
                        item.Expired = true;
                        //update database
                        db.SaveChanges();
                        // continue the iteration
                        continue;
                    }
                    item.Expired = false;
                    db.SaveChanges();
                }
            }

            // 3. Return result
            return View(sortedRequests);
        }


        // GET: Rent/RentalRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalRequest rentalRequest = db.RentalRequests.Find(id);
            if (rentalRequest == null)
            {
                return HttpNotFound();
            }
            return View(rentalRequest);
        }

        // GET: Rent/RentalRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rent/RentalRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime,ProjectInfo,RentalCode,Accepted,ContractSigned,Expired")] RentalRequest rentalRequest)
        {
            if (ModelState.IsValid)
            {
                db.RentalRequests.Add(rentalRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentalRequest);
        }

        // GET: Rent/RentalRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalRequest rentalRequest = db.RentalRequests.Find(id);
            if (rentalRequest == null)
            {
                return HttpNotFound();
            }
            return View(rentalRequest);
        }

        // POST: Rent/RentalRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalRequestID,ContactPerson,Company,RequestedTime,StartTime,EndTime,ProjectInfo,RentalCode,Accepted,ContractSigned,Expired")] RentalRequest rentalRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rentalRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rentalRequest);
        }

        // GET: Rent/RentalRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentalRequest rentalRequest = db.RentalRequests.Find(id);
            if (rentalRequest == null)
            {
                return HttpNotFound();
            }
            return View(rentalRequest);
        }

        // POST: Rent/RentalRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RentalRequest rentalRequest = db.RentalRequests.Find(id);
            db.RentalRequests.Remove(rentalRequest);
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