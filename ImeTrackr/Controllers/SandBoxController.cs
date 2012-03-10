using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImeTrackr.Models;
using ImeTrackr.DAL;

namespace ImeTrackr.Controllers
{
    public class SandBoxController : Controller
    {
        ImeTrackrContext db = new ImeTrackrContext();
        //
        // GET: /SandBox/

        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public JsonResult JsonTest(Plaintiff plaintiff)
        {
            db.Plaintiffs.Add(plaintiff);
            return Json(plaintiff);
        }

        //
        // GET: /SandBox/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SandBox/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SandBox/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /SandBox/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /SandBox/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SandBox/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /SandBox/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
