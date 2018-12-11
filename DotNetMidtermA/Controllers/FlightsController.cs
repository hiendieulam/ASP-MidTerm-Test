using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetMidtermA.Models;

namespace DotNetMidtermA.Controllers
{
    [Authorize]
    public class FlightsController : Controller
    {
        private FlightModel db = new FlightModel();

        // GET: Flights
        [AllowAnonymous]
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.FlightType).Include(f => f.Province).OrderBy(f => f.LastName).ThenBy(f => f.FirstName);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.FlightTypeId = new SelectList(db.FlightTypes, "FlightTypeId", "FlightType1");
            ViewBag.ProvinceId = new SelectList(db.Provinces.OrderBy(f => f.Name), "ProvinceId", "Name");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlightId,FlightTypeId,ProvinceId,ExtraBag,FirstName,LastName")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlightTypeId = new SelectList(db.FlightTypes, "FlightTypeId", "FlightType1", flight.FlightTypeId);
            ViewBag.ProvinceId = new SelectList(db.Provinces.OrderBy(f => f.Name), "ProvinceId", "Name", flight.ProvinceId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlightTypeId = new SelectList(db.FlightTypes, "FlightTypeId", "FlightType1", flight.FlightTypeId);
            ViewBag.ProvinceId = new SelectList(db.Provinces.OrderBy(f => f.Name), "ProvinceId", "Name", flight.ProvinceId);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlightId,FlightTypeId,ProvinceId,ExtraBag,FirstName,LastName")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlightTypeId = new SelectList(db.FlightTypes, "FlightTypeId", "FlightType1", flight.FlightTypeId);
            ViewBag.ProvinceId = new SelectList(db.Provinces.OrderBy(f => f.Name), "ProvinceId", "Name", flight.ProvinceId);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
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
