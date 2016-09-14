namespace TestRailMVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Web.Mvc;
    using TestRailMVC.Models; // Added to access our model resources.

    internal sealed class Configuration : DbMigrationsConfiguration<TestRailMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestRailMVC.Models.ApplicationDbContext context)
        {
            // Dummy data
            var u1 = new ApplicationUser()
            {
                Id = "1",
                Forename = "Richard",
                Surname = "Bundock",
                Email = "richard.bundock@cohaesus.co.uk",
                UserName = "Richard Bundock"
            };

            var u2 = new ApplicationUser()
            {
                Id = "2",
                Forename = "Phil",
                Surname = "Beaman",
                Email = "philip.beaman@cohaesus.co.uk",
                UserName = "Phil Beaman"
            };

            var u3 = new ApplicationUser()
            {
                Id = "3",
                Forename = "Matt",
                Surname = "Meckes",
                Email = "matt.meckes@cohaesus.co.uk",
                UserName = "Matt Meckes"
            };

            var u4 = new ApplicationUser()
            {
                Id = "bd65f43c-6045-45d9-93c9-60c516831629",
                Forename = "Andrew",
                Surname = "Dick",
                Email = "andrew.dick@cohaesus.co.uk",
                UserName = "Andrew Dick"
            };


            var p1 = new Project()
            {
                Id = 1,
                Name = "WWF Endangered Emoji",
                Code = "281MM134",
                Description = "Allows users to tweet a series of emoji associated based on endangered species."
            };

            var p2 = new Project()
            {
                Id = 2,
                Name = "Majestic Wine App",
                Code = "198RB001",
                Description = "A Xamarin-based app that allows customers to purchase wine"
            };

            var p3 = new Project()
            {
                Id = 3,
                Name = "Workspace Annual Report",
                Code = "341SB011",
                Description = "A digital annual report for the Workspace Group"
            };


            var tc1 = new TestCase()
            {
                Id = 1,
                Title = "Left clicking on the main logo redirects to homepage",
                Precondition = "",
                Step = "Left click on the main logo on any page",
                Comment = ""
            };

            var tc2 = new TestCase()
            {
                Id = 2,
                Title = "Google map renders on the Where we Are page and shows the office location",
                Precondition = "Some random precondition that I can't think of at this moment in time",
                Step = "Navigate to Where we are. Observe map.",
                Comment = "Map renders but the location is incorrect"
            };

            var tc3 = new TestCase()
            {
                Id = 3,
                Title = "Custom fonts display correctly",
                Precondition = "",
                Step = "",
                Comment = ""
            };


            // Allocations
            u1.Projects = new List<Project>() { p1, p2, p3 };
            u2.Projects = new List<Project>() { p1, p2 };
            u3.Projects = new List<Project>() { p1 };
            u4.Projects = new List<Project>() { p1, p2 };

            p1.TestCases = new List<TestCase>() { tc3 };
            p2.TestCases = new List<TestCase>() { tc1 };
            p3.TestCases = new List<TestCase>() { tc2 };


            // Seed the database
            context.Users.AddOrUpdate(u1, u2, u3);
            context.Projects.AddOrUpdate(p1, p2, p3);
            context.TestCases.AddOrUpdate(tc1, tc2, tc3);
        }

    }
}
