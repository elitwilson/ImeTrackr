﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImeTrackr.Models;
using ImeTrackr.DAL;

namespace ImeTrackr.Controllers
{ 
    public class EvaluationController : Controller
    {
        private ImeTrackrContext db = new ImeTrackrContext();

        //
        // GET: /Evaluation/
        public ViewResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Plaintiff)
                //.Include(e => e.Contact.Organization.Name)
                .Include(e => e.Contact)
                .Include(e => e.Tech)
                .OrderBy(e => e.Plaintiff.LastName);
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
                    ViewBag.ContactId = new SelectList(db.Contacts, "Id", "Name");
                    return Json(contact, JsonRequestBehavior.AllowGet);
                }
                db.Contacts.Add(contact);
                db.SaveChanges();
                return Json("Success2");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return Json("Success3");
        }

        public ViewResult Details(int id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            return View(evaluation);
        }

        //
        // GET: /Evaluation/Create

        public ActionResult Create()
        {
            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FullName");
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            ViewBag.ContactId = new SelectList(db.Contacts.OrderBy(c => c.LastName), "Id", "LastFirst");

            

            ViewBag.TechId = new SelectList(db.Techs.OrderBy(t => t.LastName), "Id", "LastFirst");
            return View();
        } 

        //
        // POST: /Evaluation/Create

        [HttpPost]
        public ActionResult Create(Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Evaluations.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FullName", evaluation.PlaintiffId);
            
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName", evaluation.ContactId);
            ViewBag.TechId = new SelectList(db.Techs, "Id", "FullName", evaluation.TechId);
            return View(evaluation);
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