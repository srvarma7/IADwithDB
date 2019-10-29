using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BMFv2.Models;
using Microsoft.AspNet.Identity;

namespace BMFv2.Controllers
{
    [RequireHttps]
    [Authorize]
    public class BookingController : Controller
    {
        private BMFEntities db = new BMFEntities();

        // GET: Booking
        public ActionResult Index()
        {
            bool isAdmin = User.IsInRole("Admin");
            //Displays booking for the current loggedin user
            if (!isAdmin)
            {
                var user = User.Identity.GetUserId();
                var bookingsList = db.Bookings.Where(s => s.AspNetUser.Id == user).ToList();
                return View(bookingsList.ToList());

            }
            //If ADMIN displays all the bookings list
            else
            {
                var bookingsList = db.Bookings.Include(b => b.AspNetUser).Include(b => b.Flight);
                return View(bookingsList.ToList());
            }
        }

        // GET: Booking/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.FlightId = new SelectList(db.Flights, "FlightId", "FlightId");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,BookingDate,AmountPaid,NoOfGuests,Id,FlightId")] Booking booking)
        {
            Flight fli = new Flight();
            var flightList = db.Flights.ToList();

            if (ModelState.IsValid)
            {
                foreach (Flight f in flightList)
                {
                    if (f.FlightId == booking.FlightId)
                    {
                        //Checkig for number of seats available for the flight
                        var number = f.NumberOfSeatsLeft;
                        if (number >= booking.NoOfGuests)
                        {
                            f.NumberOfSeatsLeft = number - booking.NoOfGuests;
                            db.Entry(f).State = EntityState.Modified;
                            db.Bookings.Add(booking);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        //If there are not enough seats available it displays an error and redirects
                        else
                        {
                            ViewBag.message = "There are only " + number + " seats left";
                            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
                            ViewBag.FlightId = new SelectList(db.Flights, "FlightId", "FlightId");
                            return View();
                        }
                    }
                }
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", booking.Id);
            ViewBag.FlightId = new SelectList(db.Flights, "FlightId", "FlightId", booking.FlightId);
            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", booking.Id);
            ViewBag.FlightId = new SelectList(db.Flights, "FlightId", "FlightId", booking.FlightId);
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,BookingDate,AmountPaid,NoOfGuests,Id,FlightId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", booking.Id);
            ViewBag.FlightId = new SelectList(db.Flights, "FlightId", "FlightId", booking.FlightId);
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
