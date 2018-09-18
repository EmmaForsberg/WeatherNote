using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherNote.Db;
using WeatherNote.Models;

namespace WeatherNote.Controllers
{
    public class WeatherNotesController : Controller
    {
        private WeatherDbContext db = new WeatherDbContext();

        // GET: WeatherNotes
        public ActionResult Index()
        {
            return View(db.Notes.ToList());
        }

        // GET: WeatherNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.WeatherNote weatherNote = db.Notes.Find(id);
            if (weatherNote == null)
            {
                return HttpNotFound();
            }
            return View(weatherNote);
        }

        // GET: WeatherNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeatherNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeatherNoteId,Date,Message")] Models.WeatherNote weatherNote)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(weatherNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weatherNote);
        }

        // GET: WeatherNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.WeatherNote weatherNote = db.Notes.Find(id);
            if (weatherNote == null)
            {
                return HttpNotFound();
            }
            return View(weatherNote);
        }

        // POST: WeatherNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeatherNoteId,Date,Message")] Models.WeatherNote weatherNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weatherNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weatherNote);
        }

        // GET: WeatherNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.WeatherNote weatherNote = db.Notes.Find(id);
            if (weatherNote == null)
            {
                return HttpNotFound();
            }
            return View(weatherNote);
        }

        // POST: WeatherNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.WeatherNote weatherNote = db.Notes.Find(id);
            db.Notes.Remove(weatherNote);
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
