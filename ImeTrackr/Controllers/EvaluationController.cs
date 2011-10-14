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
            var evaluations = db.Evaluations.Include(e => e.Plaintiff).Include(e => e.Organization).OrderBy(e => e.Plaintiff.LastName);

            return View(evaluations.ToList());
        }

        //
        // POST: /Evaluation - CheckBoxes
        [HttpPost]
        public ActionResult Index(int Id)
        {
            
            return RedirectToAction("Index");
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

            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.TechId = new SelectList(db.Techs, "Id", "Initials");
            return View();
        }   

        //
        // POST: /Evaluation/Create

        [HttpPost]
        public ActionResult Create(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {

                evaluation.IsComplete = false;
                db.Evaluations.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            ViewBag.TechId = new SelectList(db.Techs, "Id", "Initials", evaluation.TechId);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", evaluation.OrganizationId);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName", evaluation.ContactId);
            return View(evaluation);
        }
        
        //
        // GET: /Evaluation/Edit/5
 
        public ActionResult Edit(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName");
            ViewBag.TechId = new SelectList(db.Techs, "Id", "Initials", evaluation.TechId);
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
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName");
            ViewBag.TechId = new SelectList(db.Techs, "Id", "Initials", evaluation.TechId);
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