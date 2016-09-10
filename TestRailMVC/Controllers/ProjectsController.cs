using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestRailMVC.Models;
using Microsoft.AspNet.Identity;


namespace TestRailMVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected UserManager<ApplicationUser> UserManager { get; set; }

        // Determine whether User belongs to a Project
        private bool IsUserAssignedToProject(int? id, Project project)
        {
            // Retrieve the current User
            var userId = User.Identity.GetUserId();
            ApplicationUser user = db.Users.Find(userId);

            // Determine whether a user belongs to a project
            if (user.Projects.Contains(project))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // GET: Projects
        public ActionResult Index()
        {
            // Determine the user currently logged in 
            var userId = User.Identity.GetUserId();

            // Find the first user in the database's User table whose primary key matches the userID
            var user = db.Users.First((u) => u.Id == userId);

            // Return all Projects that the User has been added to
            return View(user.Projects);

        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Project project = db.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }


            if (IsUserAssignedToProject(id, project))
            {
                return View(project);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Code,Description,Users")] Project project)
        {
            if (ModelState.IsValid)
            {
                // Determine the user currently logged in 
                var userId = User.Identity.GetUserId();

                // Find the first user in the database's User table whose primary key matches the userID
                var user = db.Users.First((u) => u.Id == userId);

                // Automatically add the logged in user to the created project
                user.Projects = new List<Project>() { project };

                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            if (IsUserAssignedToProject(id, project))
            {
                return View(project);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Code,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            if (IsUserAssignedToProject(id, project))
            {
                return View(project);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
