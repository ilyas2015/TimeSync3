using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Timesheet.Data;
using TimeSync3.Models;

namespace TimeSync3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        public RolesController()
        {
        }

        public RolesController(ApplicationUserManager userManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        //
        // GET: /Roles/
        public ActionResult Index()
        {
            //var roles = RoleManager.Roles.ToList();
            //ViewBag.DataSource = RoleManager.Roles;
            List<RoleViewModel> roles = new List<RoleViewModel>();
            
            foreach (var dbRole in RoleManager.Roles)
            {
                var role = new RoleViewModel{ Id = dbRole.Id, Name = dbRole.Name };
                roles.Add(role);
            }
            ViewBag.datasource = roles;
            return View();
        }

        //
        // GET: /Roles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in UserManager.Users.ToList())
            {
                if (await UserManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }

        //
        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleViewModel.Name);
                var roleresult = await RoleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpPost]
        //public async Task<ActionResult> PostRoleCreate(RoleViewModel roleViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var role = new IdentityRole(roleViewModel.Name);
        //        var roleresult = await RoleManager.CreateAsync(role);
        //        //if (!roleresult.Succeeded)
        //        //{
        //        //    ModelState.AddModelError("", roleresult.Errors.First());
        //        //    return View();
        //        //}
        //        roleViewModel.Id = role.Id;
        //        return Json(roleViewModel, JsonRequestBehavior.AllowGet);
        //        //return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        ////[HttpPost]
        //public ActionResult RoleCreate(RoleViewModel roleViewModel)
        //{
        //    var result = PostRoleCreate(roleViewModel);
        //    return Json(roleViewModel, JsonRequestBehavior.AllowGet);
        //}
        //
        // GET: /Roles/Edit/Admin
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            RoleViewModel roleModel = new RoleViewModel { Id = role.Id, Name = role.Name };
            return View(roleModel);
        }

        //
        // POST: /Roles/Edit/5
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                await RoleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        //
        // GET: /Roles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await RoleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        //
        // POST: /Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id) // , string deleteUser
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await RoleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                result = await RoleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult RoleUpdate(RoleViewModel value)
        {
            var role = RoleManager.FindById(value.Id);
            role.Name = value.Name;
            RoleManager.Update(role);
            value.Id = role.Id;
            value.Name = role.Name;
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RoleDelete(string key)
        {
            var dRole =  RoleManager.FindById(key);
            if (dRole == null)
            {
                return HttpNotFound();
            }
            IdentityResult result;
            result = RoleManager.Delete(dRole);

            List<RoleViewModel> roles = new List<RoleViewModel>();

            foreach (var dbRole in RoleManager.Roles)
            {
                var role = new RoleViewModel { Id = dbRole.Id, Name = dbRole.Name };
                roles.Add(role);
            }

            return Json(roles, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RoleInsert(RoleViewModel value)
        {
            var iRole = new IdentityRole(value.Name);
            var roleresult = RoleManager.Create(iRole);
            
            //List<RoleViewModel> roles = new List<RoleViewModel>();
            
            //foreach (var dbRole in RoleManager.Roles)
            //{
            //    var role = new RoleViewModel { Id = dbRole.Id, Name = dbRole.Name };
            //    roles.Add(role);
            //}

            return Json(iRole, JsonRequestBehavior.AllowGet);
        }
    }
}