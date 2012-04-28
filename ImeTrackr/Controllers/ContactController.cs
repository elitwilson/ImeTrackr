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
    public class ContactController : Controller
    {
        private ImeTrackrContext db = new ImeTrackrContext();

        //
        // GET: /Contact/

        public ViewResult Index()
        {
            var contacts = db.Contacts.Include(c => c.Organization).OrderBy(c => c.LastName);
            return View(contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ViewResult Details(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        } 

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return null;
                }
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", contact.OrganizationId);
            return View(contact);
        }

        public ActionResult _CreateContact()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return PartialView();
        }

        [HttpPost]
        public ActionResult _CreateContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return View("Evaluation");
            }

            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return View();
        }

        public ActionResult CreatePartial()
        {
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name");
            return PartialView("_CreateContact");
        }
        
        //
        // GET: /Contact/Edit/5
 
        public ActionResult Edit(int id)
        {
            Contact contact = db.Contacts.Find(id);
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", contact.OrganizationId);
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationId = new SelectList(db.Organizations, "Id", "Name", contact.OrganizationId);
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewBag.Message = "Are you sure you want to delete?"; 
            Contact contact = db.Contacts.Find(id);
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            try
            {
                Contact contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                Contact contact = db.Contacts.Find(id);
                ViewBag.Message = "Cannot Delete";
                return View(contact);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}