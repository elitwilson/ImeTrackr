using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImeTrackr.Models;

namespace ImeTrackr.Controllers
{ 
    public class PlaintiffController : Controller
    {
        private ImeTrackrContext db = new ImeTrackrContext();

        //
        // GET: /Plaintiff/

        public ViewResult Index()
        {
            var plaintiffs = db.Plaintiffs.Include(p => p.Evaluations);
            return View(plaintiffs.ToList());
        }

        //
        // GET: /Plaintiff/Details/5

        public ViewResult Details(int id)
        {
            Plaintiff plaintiff = db.Plaintiffs.Find(id);
            return View(plaintiff);
        }

        //
        // GET: /Plaintiff/Create

        public ActionResult Create()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FirstName");
            return View();
        } 

        //
        // POST: /Plaintiff/Create

        [HttpPost]
        public ActionResult Create(Plaintiff plaintiff)
        {
            if (ModelState.IsValid)
            {
                db.Plaintiffs.Add(plaintiff);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            //ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FirstName", plaintiff.ContactId);
            return View(plaintiff);
        }
        
        //
        // GET: /Plaintiff/Edit/5
 
        public ActionResult Edit(int id)
        {
            Plaintiff plaintiff = db.Plaintiffs.Find(id);
            //ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FirstName", plaintiff.ContactId);
            return View(plaintiff);
        }

        //
        // POST: /Plaintiff/Edit/5

        [HttpPost]
        public ActionResult Edit(Plaintiff plaintiff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plaintiff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FirstName", plaintiff.ContactId);
            return View(plaintiff);
        }

        //
        // GET: /Plaintiff/Delete/5
 
        public ActionResult Delete(int id)
        {
            Plaintiff plaintiff = db.Plaintiffs.Find(id);
            return View(plaintiff);
        }

        //
        // POST: /Plaintiff/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Plaintiff plaintiff = db.Plaintiffs.Find(id);
            db.Plaintiffs.Remove(plaintiff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}