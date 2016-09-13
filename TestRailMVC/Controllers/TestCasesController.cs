using Microsoft.AspNet.Identity;
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
    public class TestCasesController : UserBaseController
    {
        public TestCase GetTestCase(int? id)
        {
            return CurrentUser.Projects.SelectMany(p => p.TestCases).SingleOrDefault(tc => tc.Id == id);
        }

        public int RetrieveProjectId(int? id)
        {
            

            return null;
        }


        // GET: TestCases
        // Unused
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

            if (GetTestCase(id) == null)
            {
                return HttpNotFound();
            }

            return View(GetTestCase(id));
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
            var tc = db.TestCases.First(t => t.Id == id );
            var projectId = tc.Project.Id;

            // Passes the Project Id to the TestCase Create view
            ViewData["ProjectId"] = projectId;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (GetTestCase(id) == null)
            {
                return HttpNotFound();
            }

            return View(GetTestCase(id));
        }

        // POST: TestCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Priority,Precondition,Step,Status,Comment")] TestCase testCase, int ProjectIdentifier)
        {

            if (ModelState.IsValid)
            {
                db.Entry(testCase).State = EntityState.Modified;
                db.SaveChanges();
                // Redirect user to the project details
                return RedirectToAction("Details", "Projects", new { id = ProjectIdentifier });
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
            if (IsUserAssignedToTestCase(testCase))
            {
                return View(testCase);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
        }

        // POST: TestCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestCase testCase = db.TestCases.Find(id);
            var projectId = testCase.Project.Id;
                 
            db.TestCases.Remove(testCase);
            db.SaveChanges();
            // Redirect user to the project details
            return RedirectToAction("Details", "Projects", new { id = projectId });
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

