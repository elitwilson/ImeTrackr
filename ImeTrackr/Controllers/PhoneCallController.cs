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
    public class PhoneCallController : BaseController
    {
        private ImeTrackrContext db = new ImeTrackrContext();
        private PhoneCall phoneCallFinal = new PhoneCall();
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
            vm.Date = DateTime.Now.Date;
            
            //I know I am doing this inefficiently. Don't need a list of entity models in VM
            //vm.Plaintiffs = db.Plaintiffs.OrderBy(p => p.LastName);
            //vm.Organizations = db.Organizations.OrderBy(o => o.Name);
            //vm.Contacts = db.Contacts.OrderBy(c => c.LastName);
            
            return View(vm);
        } 

        //
        // POST: /PhoneCall/Create
        [HttpPost]
        public string Create(PhoneCallViewModel phoneCall)
        {
            if (ModelState.IsValid)
            {
                var possibleContacts = from item in db.Contacts
                                       where item.FirstName.ToLower().StartsWith(phoneCall.ContactFirstName) ||
                                       item.LastName.ToLower().StartsWith(phoneCall.ContactLastName)
                                       orderby item.LastName
                                       select new { item.Id, item.FirstName, item.LastName };

                foreach (var item in possibleContacts)
                {
                    PhoneCallViewModel.ContactMatch cMatch = new PhoneCallViewModel.ContactMatch();
                    cMatch.ContactId = item.Id;
                    cMatch.FullName = item.FirstName + " " + item.LastName;
                    phoneCall.ContactMatches.Add(cMatch);
                }
                
                var possiblePlaintiffs = from item in db.Plaintiffs
                                         where item.FirstName.ToLower().StartsWith(phoneCall.PlaintiffFirstName) ||
                                         item.LastName.ToLower().StartsWith(phoneCall.PlaintiffLastName)
                                         orderby item.LastName
                                         select new { item.Id, item.FirstName, item.LastName };

                foreach (var item in possiblePlaintiffs)
                {
                    PhoneCallViewModel.PlaintiffMatch pMatch = new PhoneCallViewModel.PlaintiffMatch();
                    pMatch.PlaintiffId = item.Id;
                    pMatch.FullName = item.FirstName + " " + item.LastName;
                    phoneCall.PlaintiffMatches.Add(pMatch);
                }
                var result = JsonConvert.SerializeObject(phoneCall);

                //   There may be a better way to do this...
                //I am storing result of form in private PhoneCall variable defined at start of controller.
                phoneCallFinal.Message = phoneCall.Message;
                phoneCallFinal.Date = phoneCall.Date;

                return result;  
            }

            return "There was a problem";
        }

        [HttpPost]
        public ActionResult AddPhoneCall(int ContactId, int PlaintiffId)
        {
            PhoneCall phoneCall = new PhoneCall();

            Contact contact = db.Contacts.Find(ContactId);
            Plaintiff plaintiff = db.Plaintiffs.Find(PlaintiffId);

            phoneCall.Contact = contact;
            phoneCall.Plaintiff = plaintiff;

            //Add to Database
            //db.PhoneCalls.Add(phoneCallFinal);
            return null;
        }

        public ActionResult AddPhoneCall(PhoneCallViewModel vm)
        {
            return null;
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

        [HttpPost]
        public string GetContactsAsJson()
        {
            var contacts = from c in db.Contacts
                        select new 
                        {
                            label = c.FirstName + " " + c.LastName,
                            value = c.Id
                        };

            var result = JsonConvert.SerializeObject(contacts);

            return result;
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