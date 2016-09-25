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
                Forename = "Test",
                Surname = "User1",
                Email = "testuser1@cohaesus.co.uk",
                UserName = "testuser1@cohaesus.co.uk"
            };

            var u2 = new ApplicationUser()
            {
                Id = "2",
                Forename = "Test",
                Surname = "User2",
                Email = "testuser2@cohaesus.co.uk",
                UserName = "testuser2@cohaesus.co.uk"
            };

            var u3 = new ApplicationUser()
            {
                Id = "3",
                Forename = "Test",
                Surname = "User3",
                Email = "testuser3@cohaesus.co.uk",
                UserName = "testuser3@cohaesus.co.uk"
            };

            var u4 = new ApplicationUser()
            {
                Id = "bd65f43c-6045-45d9-93c9-60c516831629",
                Forename = "Andrew",
                Surname = "Dick",
                Email = "andrew.dick@cohaesus.co.uk",
                UserName = "andrew.dick@cohaesus.co.uk"
            };


            var p1 = new Project()
            {
                Id = 1,
                Name = "Test Project 1",
                Code = "281TP134",
                Description = "A Facebook App that allows users to donate to charity"
            };

            var p2 = new Project()
            {
                Id = 2,
                Name = "Test Project 2",
                Code = "198TP001",
                Description = "A Xamarin-based app that allows customers to purchase pc components"
            };

            var p3 = new Project()
            {
                Id = 3,
                Name = "Test Project 3",
                Code = "341TP011",
                Description = "A digital annual report for the Test Project group"
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
                Precondition = "Internet Explorer 10 and above",
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
