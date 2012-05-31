using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using ImeTrackr.DAL;
using ImeTrackr.Models;


namespace ImeTrackr.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ImeTrackrContext db = new ImeTrackrContext();

        public ActionResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Plaintiff)
                .Include(e => e.Contact)
                .Where(e => e.IsComplete == false)
                .OrderBy(e => e.DayTwo);
            var repo = new DbRepository();

            //Call to daily backup method
            //repo.AutoBackupDB();

            ViewBag.Message = "Currently Open Evaluations";

            return View(evaluations.ToList());
        }

        public ActionResult Backup()
        {
            var repo = new DbRepository();
            repo.BackupDB();
            return RedirectToAction("Index");
        }

        public ActionResult Restore()
        {
            var repo = new DbRepository();
            repo.RestoreDb();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
