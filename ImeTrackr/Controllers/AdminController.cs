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
        [HttpGet]
        public ActionResult Edit(string user)
        {
            AdminEditUser editModel = new AdminEditUser();
            MembershipUser currentUser = Membership.GetUser(user);
            


            editModel.UserName = currentUser.UserName;
            editModel.Email = currentUser.Email;
            editModel.Comment = currentUser.Comment;
            editModel.SelectedRoleNames = Roles.GetRolesForUser(user);
            
            return View(editModel);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(AdminEditUser model)
        {
            if (ModelState.IsValid)
            {
                var user = Membership.GetUser(model.UserName);
                user.Comment = model.Comment;
                user.Email = model.Email;
                var rolesForUser = Roles.GetRolesForUser(model.UserName);

                if (rolesForUser != null && rolesForUser.Count() > 0)
                {
                    Roles.RemoveUserFromRoles(model.UserName, rolesForUser);
                }
                if (model.SelectedRoleNames != null)
                {
                    foreach (var role in model.SelectedRoleNames)
                    {

                        Roles.AddUserToRole(user.UserName, role);
                    }
                }

                Membership.UpdateUser(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /Admin/Delete/5
        public ActionResult Delete(String user)
        {
            AdminEditUser vm = new AdminEditUser();
            return View("Delete");
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
