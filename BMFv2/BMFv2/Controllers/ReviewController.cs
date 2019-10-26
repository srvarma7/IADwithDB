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
    public class ReviewController : Controller
    {
        private BMFEntities db = new BMFEntities();

        // GET: Review
        public ActionResult Index()
        {
            bool isAdmin = User.IsInRole("Admin");
            if (!isAdmin)
            {
                var user = User.Identity.GetUserId();
                var reviews = db.Reviews.Where(s => s.AspNetUser.Id == user).ToList();
                return View(reviews.ToList());

            }
            else
            {
                var reviews = db.Reviews.Include(r => r.AspNetUser).Include(r => r.Booking);
                return View(reviews.ToList());
            }
        }

        // GET: Review/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "BookingId");
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewId,Rating,RatingComment,Id,BookingId")] Review review)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Reviews.Add(review);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                  String error =  e.ToString();
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", review.Id);
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "Id", review.BookingId);
            return View(review);
        }

        // GET: Review/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", review.Id);
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "Id", review.BookingId);
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewId,Rating,RatingComment,Id,BookingId")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.AspNetUsers, "Id", "Email", review.Id);
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "Id", review.BookingId);
            return View(review);
        }

        // GET: Review/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
