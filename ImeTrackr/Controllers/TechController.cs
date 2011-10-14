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
    public class TechController : Controller
    {
        private ImeTrackrContext db = new ImeTrackrContext();

        //
        // GET: /Tech/

        public ViewResult Index()
        {
            return View(db.Techs.ToList());
        }

        //
        // GET: /Tech/Details/5

        public ViewResult Details(int id)
        {
            Tech tech = db.Techs.Find(id);
            return View(tech);
        }

        //
        // GET: /Tech/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Tech/Create

        [HttpPost]
        public ActionResult Create(Tech tech)
        {
            if (ModelState.IsValid)
            {
                db.Techs.Add(tech);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(tech);
        }
        
        //
        // GET: /Tech/Edit/5
 
        public ActionResult Edit(int id)
        {
            Tech tech = db.Techs.Find(id);
            return View(tech);
        }

        //
        // POST: /Tech/Edit/5

        [HttpPost]
        public ActionResult Edit(Tech tech)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tech).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tech);
        }

        //
        // GET: /Tech/Delete/5
 
        public ActionResult Delete(int id)
        {
            Tech tech = db.Techs.Find(id);
            return View(tech);
        }

        //
        // POST: /Tech/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Tech tech = db.Techs.Find(id);
            db.Techs.Remove(tech);
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