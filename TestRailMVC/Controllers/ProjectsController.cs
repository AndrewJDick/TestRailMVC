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
    public class AuthenticatedBaseController : UserBaseController
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
    }

    [Authorize]
    public class ProjectsController : AuthenticatedBaseController
    {
        public Project GetUserProject(int? id)
        {
            // Either returns the project (confirming the user belongs to the project), null, or an exception if multiple id's are found. 
            return CurrentUser.Projects.SingleOrDefault(p => p.Id == id);
        }

        // GET: Projects
        public ActionResult Index(int? id)
        {
            // Return all Projects that the User has been added to
            return View(CurrentUser.Projects);
        }

        
        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {            
            // Passes the Project Id to a hidden field in the Project User partial view
            ViewData["ProjectId"] = id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (GetUserProject(id) == null)
            {
                return HttpNotFound();
            }

            return View(GetUserProject(id));
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
                // Automatically add the logged in user to the created project
                CurrentUser.Projects = new List<Project>() { project };

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

            if (GetUserProject(id) == null)
            {
                return HttpNotFound();
            }

            return View(GetUserProject(id));
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

            if (GetUserProject(id) == null)
            {
                return HttpNotFound();
            }

            return View(GetUserProject(id));
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = GetUserProject(id);
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

        // POST: RemoveUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUser(int ProjectIdentifier, string UserIdentifier)
        {
            Project project = CurrentUser.Projects.FirstOrDefault(p => p.Id == ProjectIdentifier);
            ApplicationUser user = db.Users.Find(UserIdentifier);

            project.Users.Remove(user);

            db.SaveChanges();
            return RedirectToAction("Details", "Projects", new { id = ProjectIdentifier });
        }
    }
}
