using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImeTrackr.Models;
using ImeTrackr.ViewModels;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace ImeTrackr.Controllers
{ 
    public class PhoneCallController : Controller
    {
        private ImeTrackrContext db = new ImeTrackrContext();
        
        //
        // GET: /PhoneCall/

        //public ViewResult Index()
        //{
        //    var phonecalls = db.PhoneCalls.Include(p => p.Contact)
        //        .OrderBy(p => p.Date);
        //    return View(phonecalls.ToList());
        //}

        public ViewResult Index(string sortOrder)
        {
            ViewBag.PlaintiffSortParm = sortOrder == "Plaintiff" ? "Plaintiff desc" : "Plaintiff";
            ViewBag.ContactSortParm = sortOrder == "Contact" ? "Contact desc" : "Contact";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            
            //var phoneCalls = from p in db.PhoneCalls
            //                 select p;

            var phoneCalls = db.PhoneCalls.Include(p => p.Contact)
                .OrderByDescending(p => p.Date);

            switch (sortOrder)
            {
                case "Date":
                    phoneCalls = phoneCalls.OrderBy(p => p.Date);
                    break;

                case "Date desc":
                    phoneCalls = phoneCalls.OrderByDescending(p => p.Date);
                    break;

                case "Plaintiff":
                    phoneCalls = phoneCalls.OrderBy(p => p.Plaintiff.LastName);
                    break;

                case "Plaintiff desc":
                    phoneCalls = phoneCalls.OrderByDescending(p => p.Plaintiff.LastName);
                    break;
                
                case "Contact":
                    phoneCalls = phoneCalls.OrderBy(p => p.Plaintiff.LastName);
                    break;

                case "Contact desc":
                    phoneCalls = phoneCalls.OrderByDescending(p => p.Plaintiff.LastName);
                    break;

                default:
                    var phonecalls = db.PhoneCalls.Include(p => p.Contact)
                        .OrderBy(p => p.Date);
                    break;
            }

            return View(phoneCalls.ToList());
        }

        //
        // GET: /PhoneCall/Details/5

        public ViewResult Details(int id)
        {
            PhoneCall phonecall = db.PhoneCalls.Find(id);
            return View(phonecall);
        }

        //
        // GET: /PhoneCall/Create

        public ActionResult Create()
        {
            PhoneCallViewModel vm = new PhoneCallViewModel();

            //I know I am doing this inefficiently. Don't need a list of entity models in VM
            vm.Date = DateTime.Now.Date;
            vm.Plaintiffs = db.Plaintiffs;
            vm.Organizations = db.Organizations;
            vm.Contacts = db.Contacts;
            
            return View(vm);
        } 

        //
        // POST: /PhoneCall/Create

        [HttpPost]
        public ActionResult Create(PhoneCall phonecall)
        {
            if (ModelState.IsValid)
            {


                db.PhoneCalls.Add(phonecall);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            //ViewBag.PlaintiffId = new SelectList(db.Plaintiffs, "Id", "FullName", phonecall.PlaintiffId);
            //ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FullName", phonecall.ContactId);
            return View(phonecall);
        }

        [HttpPost]
        public ActionResult PopulateContacts(int id)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var query = from obj in db.Contacts
                        where obj.OrganizationId == id
                        select new { obj.Id, obj.LastName, obj.FirstName };

            //var result = serializer.Serialize(query);

            var result = JsonConvert.SerializeObject(query);

            return Json(result);

        }
        
        //
        // GET: /PhoneCall/Edit/5
 
        public ActionResult Edit(int id)
        {
            PhoneCall phonecall = db.PhoneCalls.Find(id);
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FirstName", phonecall.ContactId);
            return View(phonecall);
        }

        //
        // POST: /PhoneCall/Edit/5

        [HttpPost]
        public ActionResult Edit(PhoneCall phonecall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phonecall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "Id", "FirstName", phonecall.ContactId);
            return View(phonecall);
        }

        //
        // GET: /PhoneCall/Delete/5
 
        public ActionResult Delete(int id)
        {
            PhoneCall phonecall = db.PhoneCalls.Find(id);
            return View(phonecall);
        }

        //
        // POST: /PhoneCall/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            PhoneCall phonecall = db.PhoneCalls.Find(id);
            db.PhoneCalls.Remove(phonecall);
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