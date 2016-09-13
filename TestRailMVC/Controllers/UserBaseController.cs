using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestRailMVC.Models;

namespace TestRailMVC.Controllers
{
    public abstract class UserBaseController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationUser CurrentUser
        {
            get
            {
                return db.Users.Find(User.Identity.GetUserId());
            }
        }
    }
}