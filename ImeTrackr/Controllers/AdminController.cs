using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ImeTrackr.Models;
using Newtonsoft.Json;

namespace ImeTrackr.Controllers
{
    //[Authorize(Roles="Administrator")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            AdminModel vm = new AdminModel();
            MembershipUserCollection users = Membership.GetAllUsers();
            vm.Users = users;

            String[] roles = Roles.GetAllRoles();
            vm.Roles = roles;
            return View(vm);
        }

        public ActionResult AddRole(String roleName)
        {
            Roles.CreateRole(roleName);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteRole(String roleName)
        {
            Roles.DeleteRole(roleName);
            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Admin/Create

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
        // GET: /Admin/Edit/5
 
        public ActionResult Edit(string user)
        {
            AdminEditUser editModel = new AdminEditUser();
            MembershipUser currentUser = Membership.GetUser(user);
            editModel.User = currentUser;
            
            editModel.UserName = currentUser.UserName;
            editModel.Email = currentUser.Email;
            editModel.Comment = currentUser.Comment;

            editModel.Roles = Roles.GetAllRoles();
            return View(editModel);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(AdminEditUser user, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Delete/5
        public ActionResult Delete(String user)
        {
            AdminEditUser vm = new AdminEditUser();
            vm.User = Membership.GetUser(user);
            return View("Delete", vm.User);
        }

        //
        // POST: /Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(String user, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Membership.DeleteUser(user);
                return RedirectToAction("Index", "Admin");
            }
            catch
            {
                return View();
            }
        }
    }
}
