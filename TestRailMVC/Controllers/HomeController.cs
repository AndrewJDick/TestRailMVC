using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TestRailMVC.Controllers
{
    [RequireHttps]
    // Adding Authorize redirects users to login page if not logged in, and homepage if they are. 
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // No landing page exists, so we'll redirect to Project Dashboard
            return RedirectToAction("Index", "Projects");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}