using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestRailMVC.Models;

namespace TestRailMVC.Controllers
{
    public class TestCasesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestCases
        public ActionResult Index()
        {
            return View(db.TestCases.ToList());
        }

        // GET: TestCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCase testCase = db.TestCases.Find(id);
            if (testCase == null)
            {
                return HttpNotFound();
            }
            return View(testCase);
        }

        public ActionResult MyNextAction()
        {
            return Redirect(Request.UrlReferrer.ToString());
        }

        // GET: TestCases/Create
        public ActionResult Create(int? id)
        {   
            var projectId = id;

            // Passes the Project Id to the TestCase Create view
            ViewData["ProjectId"] = projectId;

            return View();
        }

        // POST: TestCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Priority,Precondition,Step,Status,Comment")] TestCase testCase, int ProjectIdentifier)
        {
            if (ModelState.IsValid)
            {
                // Determine the project id where the test case was created
                var projectId = ProjectIdentifier;

                // Find the first project in the database's Projects table whose primary key matches the projectID
                var project = db.Projects.First((p) => p.Id == projectId);

                // Add the newly-created test case to the project
                project.TestCases.Add(testCase);

                db.SaveChanges();
                return RedirectToAction("Details", "Projects", new { id = ProjectIdentifier });
            }

            return View(testCase);
        }

        // GET: TestCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCase testCase = db.TestCases.Find(id);
            if (testCase == null)
            {
                return HttpNotFound();
            }
            return View(testCase);
        }

        // POST: TestCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Priority,Precondition,Step,Status,Comment")] TestCase testCase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testCase).State = EntityState.Modified;
                db.SaveChanges();
                // TODO - Redirect user to the project the test cases belongs to, rather than the dashboard.
                return RedirectToAction("Index", "Projects");
            }
            return View(testCase.Project.Id);
        }

        // GET: TestCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestCase testCase = db.TestCases.Find(id);
            if (testCase == null)
            {
                return HttpNotFound();
            }
            return View(testCase);
        }

        // POST: TestCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestCase testCase = db.TestCases.Find(id);
            db.TestCases.Remove(testCase);
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
