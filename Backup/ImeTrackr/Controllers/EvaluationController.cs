using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImeTrackr.Models;
using ImeTrackr.DAL;
using ImeTrackr.ViewModels;
using Newtonsoft.Json;

namespace ImeTrackr.Controllers
{ 
    public class EvaluationController : BaseController
    {
        private ImeTrackrContext db = new ImeTrackrContext();

        //
        // GET: /Evaluation/
        public ViewResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Plaintiff)
                .Include(e => e.Contact)
                .Include(e => e.Tech)
                .OrderByDescending(e => e.DayTwo);
            return View(evaluations.ToList());
        }

        //
        // GET: /Evaluation/Details/5
        public ActionResult _CreateContact()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return PartialView();
        }

        //
        // POST
        [HttpPost]
        public JsonResult _CreateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();

                    return Json(contact, JsonRequestBehavior.AllowGet);
                }
                db.Contacts.Add(contact);
                db.SaveChanges();
                return Json(contact, JsonRequestBehavior.AllowGet);
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return Json("Success3");
        }

        public ViewResult Details(int id)
        {
            EvaluationViewModel vm = new EvaluationViewModel();
            Evaluation evaluation = db.Evaluations.Find(id);

            vm.Evaluation = evaluation;
            vm.Plaintiff = evaluation.Plaintiff;
            
            if (evaluation.OrganizationId != null)
            {
                Organization organization = db.Organizations.SingleOrDefault(o => o.Id == evaluation.OrganizationId);
                vm.Organization = organization;

            }
            if (evaluation.Contact != null)
            {
                Contact contact = db.Contacts.SingleOrDefault(c => c.Id == evaluation.ContactId);
                vm.Contact = contact;
            }

            return View(vm);
        }
        
        private static IEnumerable<Contact> GetContacts()
        {
            IEnumerable<Contact> contacts;
            using (ImeTrackrContext db = new ImeTrackrContext())
            {
                contacts = (from one in db.Contacts
                            orderby one.LastName
                            select one).ToList();
            }
            ImeTrackrContext context = new ImeTrackrContext();
            return contacts;
        }

        //
        // GET: /Evaluation/Create
        public ActionResult Create()
        {
            EvaluationViewModel vm = new EvaluationViewModel();
            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FullName");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.ContactId = new SelectList(db.Contacts.OrderBy(c => c.LastName), "Id", "LastFirst");
            ViewBag.TechId = new SelectList(db.Techs.OrderBy(t => t.LastName), "Id", "LastFirst");
            return View();
        }


        //
        // POST: /Evaluation/Create

        [HttpPost]
        public ActionResult Create(EvaluationViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                vm.Evaluation.Plaintiff = vm.Plaintiff;
                vm.Evaluation.ContactId = vm.ContactId;
                vm.Evaluation.TechId = vm.TechId;

                //Set this Evaluation's OrganizationId to the OrganizationId of selected Contact
                Contact contact = db.Contacts.SingleOrDefault(c => c.Id == vm.ContactId);
                Organization organization = db.Organizations.SingleOrDefault(o => o.Id == contact.OrganizationId);
                vm.Evaluation.OrganizationId = organization.Id;

                db.Plaintiffs.Add(vm.Plaintiff);
                db.Evaluations.Add(vm.Evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return RedirectToAction("Create");
        }
        
        //
        // GET: /Evaluation/Edit/5
 
        public ActionResult Edit(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FullName");
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName", evaluation.ContactId);
            ViewBag.TechId = new SelectList(db.Techs, "Id", "FullName", evaluation.TechId);
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
            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FullName");
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName", evaluation.ContactId);
            ViewBag.TechId = new SelectList(db.Techs, "Id", "FullName", evaluation.TechId);
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