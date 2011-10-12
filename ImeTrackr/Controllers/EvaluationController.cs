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
    public class EvaluationController : Controller
    {
        private ImeTrackrContext db = new ImeTrackrContext();

        //
        // GET: /Evaluation/

        public ViewResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Plaintiff).Include(e => e.Organization);
            return View(evaluations.ToList());
        }

        //
        // GET: /Evaluation/Details/5

        public ViewResult Details(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            return View(evaluation);
        }

        //
        // GET: /Evaluation/Create

        public ActionResult Create()
        {

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        } 

        //
        // POST: /Evaluation/Create

        [HttpPost]
        public ActionResult Create(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                Plaintiff plaintiff = new Plaintiff();
                evaluation.Plaintiff = plaintiff;
                db.Plaintiffs.Add(plaintiff);
                
                db.Evaluations.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", evaluation.OrganizationId);
            return View(evaluation);
        }
        
        //
        // GET: /Evaluation/Edit/5
 
        public ActionResult Edit(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FirstName", evaluation.PlaintiffId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", evaluation.OrganizationId);
            return View(evaluation);
        }

        //
        // POST: /Evaluation/Edit/5

        [HttpPost]
        public ActionResult Edit(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FirstName", evaluation.PlaintiffId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", evaluation.OrganizationId);
            return View(evaluation);
        }

        //
        // GET: /Evaluation/Delete/5
 
        public ActionResult Delete(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            return View(evaluation);
        }

        //
        // POST: /Evaluation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Evaluation evaluation = db.Evaluations.Find(id);
            db.Evaluations.Remove(evaluation);
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