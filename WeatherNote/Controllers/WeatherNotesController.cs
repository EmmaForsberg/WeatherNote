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
using WeatherNote.ViewModel;

namespace WeatherNote.Controllers
{
    public class WeatherNotesController : Controller
    {
        private WeatherDbContext db = new WeatherDbContext();

        // GET: WeatherNotes
        public ActionResult Index()
        {
            var apiclass = new ApiImplementation.TemperaturApi();
            apiclass.TempRequest();
           var mytemperaturlist = apiclass.ReturningTemperatures();

            var notes = db.Notes.ToList();

            var viewmodel = new NoteTempViewModel
            {
                Notes = notes,
                Temps = mytemperaturlist
            };

            return View(viewmodel);
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
