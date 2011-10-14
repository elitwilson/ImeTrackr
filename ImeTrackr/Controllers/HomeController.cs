using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ImeTrackr.Models;

namespace ImeTrackr.Controllers
{
    public class HomeController : Controller
    {
        ImeTrackrContext db = new ImeTrackrContext();

        public ActionResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Plaintiff)
                .Include(e => e.Organization)
                .Where(e => e.IsComplete == false)
                .OrderBy(e => e.DayTwo);
            
            ViewBag.Message = "Currently Open Evaluations";

            return View(evaluations.ToList());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
