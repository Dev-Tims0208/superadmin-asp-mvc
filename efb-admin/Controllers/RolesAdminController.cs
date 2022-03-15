using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using efb_admin.Models;

namespace efb_admin.Controllers
{
    public class RolesAdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: RolesAdmin
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }


        public ActionResult ListUsers()
        {
            var users = context.Users.OrderBy(u => u.UserName).ToList();
            return View(User);
        }

        // GET:
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesAdmin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            IdentityResult ir = new IdentityResult();
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole(collection["RoleName"]));

            if (ir.Succeeded)
            {
                return RedirectToAction("Index"); 
            }
            else
            {
                ViewBag.ErrorMessage = ir.Errors.ToString();
                return View();
            }
        }
    }
}