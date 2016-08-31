namespace TestRailMVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TestRailMVC.Models; // Added to access our model resources.

    internal sealed class Configuration : DbMigrationsConfiguration<TestRailMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestRailMVC.Models.ApplicationDbContext context)
        {
            context.Projects.AddOrUpdate(x => x.Id,
                new Project()
                {
                    Id = 1,
                    Name = "WWF Endangered Emoji",
                    Code = "281MM134",
                    Description = "Allows users to tweet a series of emoji associated based on endangered species."
                },
                new Project()
                {
                    Id = 2,
                    Name = "Majestic Wine App",
                    Code = "198RB001",
                    Description = "A Xamarin-based app that allows customers to purchase wine"
                },
                new Project()
                {
                    Id = 3,
                    Name = "Workspace Annual Report",
                    Code = "341SB011",
                    Description = "A digital annual report for the Workspace Group"
                }
            );

            context.TestCases.AddOrUpdate(x => x.Id,
                new TestCase()
                {
                    Id = 1,
                    Title = "Left clicking on the main logo redirects to homepage",
                    Priority = 2,
                    Precondition = "",
                    Step = "Left click on the main logo on any page",
                    Status = "Pass",
                    Comment = ""
                },
                new TestCase()
                {
                    Id = 2,
                    Title = "Google map renders on the Where we Are page and shows the office location",
                    Priority = 3,
                    Precondition = "Some random precondition that I can't think of at this moment in time",
                    Step = "Navigate to Where we are. Observe map.",
                    Status = "Fail",
                    Comment = "Map renders but the location is incorrect"
                },
                new TestCase()
                {
                    Id = 3,
                    Title = "Custom fonts display correctly",
                    Priority = 5,
                    Precondition = "",
                    Step = "",
                    Status = "",
                    Comment = ""
                }
            );

            context.Users.AddOrUpdate(x => x.Id,
                new ApplicationUser()
                {
                    Id = "1",
                    Forename = "Richard",
                    Surname = "Bundock",
                    Email = "richard.bundock@cohaesus.co.uk",
                    UserName = "Richard Bundock"
                },
                new ApplicationUser()
                {
                    Id = "2",
                    Forename = "Phil",
                    Surname = "Beaman",
                    Email = "philip.beaman@cohaesus.co.uk",
                    UserName = "Phil Beaman"
                },
                new ApplicationUser()
                {
                    Id = "3",
                    Forename = "Matt",
                    Surname = "Meckes",
                    Email = "matt.meckes@cohaesus.co.uk",
                    UserName = "Matt Meckes"
                }
            );
        }
    }
}
