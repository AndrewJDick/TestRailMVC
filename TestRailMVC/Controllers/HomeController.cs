using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestRailMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            ViewBag.Message = "Create a project form.";

            return View();
        }

        public ActionResult CreateTestCase()
        {
            ViewBag.Message = "Create a Test Case form.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}