using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AthleteDataTrackerv2.Models;

namespace AthleteDataTrackerv2.Controllers
{
    public class AthleteResultsController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: AthleteResults
        public ActionResult Index()
        {
            return View(db.AthleteResults.OrderBy(s => s.Athlete.LName).ToList());
        }

        // GET: AthleteResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AthleteResult athleteResult = db.AthleteResults.Find(id);
            if (athleteResult == null)
            {
                return HttpNotFound();
            }
            return View(athleteResult);
        }

        // GET: AthleteResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AthleteResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AID,EID,EventDate,LID,RaceTime")] AthleteResult athleteResult)
        {
            if (ModelState.IsValid)
            {
                db.AthleteResults.Add(athleteResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(athleteResult);
        }

        // GET: AthleteResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AthleteResult athleteResult = db.AthleteResults.Find(id);
            if (athleteResult == null)
            {
                return HttpNotFound();
            }
            return View(athleteResult);
        }

        // POST: AthleteResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AID,EID,EventDate,LID,RaceTime")] AthleteResult athleteResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(athleteResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(athleteResult);
        }

        // GET: AthleteResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AthleteResult athleteResult = db.AthleteResults.Find(id);
            if (athleteResult == null)
            {
                return HttpNotFound();
            }
            return View(athleteResult);
        }

        // POST: AthleteResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AthleteResult athleteResult = db.AthleteResults.Find(id);
            db.AthleteResults.Remove(athleteResult);
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
