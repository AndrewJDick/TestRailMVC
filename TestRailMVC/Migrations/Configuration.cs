namespace TestRailMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestRailMVC.Models; // Added to access the project models.

    internal sealed class Configuration : DbMigrationsConfiguration<TestRailMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TestRailMVC.Models.ApplicationDbContext";
        }

        protected override void Seed(TestRailMVC.Models.ApplicationDbContext context)
        {
            context.Projects.AddOrUpdate(x => x.Id,
                new Project()
                {
                    Id = 1,
                    Name = "Workspace Annual Report",
                    Code = "241SB021",
                    Description = "An annual report for the Workspace group, built using handlebars."
                },
                new Project()
                {
                    Id = 2,
                    Name = "WWF Endangered Emoji",
                    Code = "256MM034",
                    Description = "A landing page that allows users to sign up and tweet a series of emojis based on endangered animals"
                },
                new Project()
                {
                    Id = 3,
                    Name = "Making Sense of Sugar",
                    Code = "112MM027",
                    Description = "A site that outlines the health risks of sugar, built using the Wordpress platform"
                }
            );

            context.TestCases.AddOrUpdate(x => x.Id,
                new TestCase()
                {
                    Id = 1,
                    Title = "Main logo returns to homepage on left mouse click",
                    Priority = 1,
                    Precondition = "",
                    Step = "Left click on the main logo",
                    Status = "Pass"
                },
                new TestCase()
                {
                    Id = 2,
                    Title = "Clicking log out logs the user out of the application",
                    Priority = 2,
                    Precondition = "Ensure user is logged in",
                    Step = "Click the log out button on the top right corner of the page",
                    Status = "Fail"
                },
                new TestCase()
                {
                    Id = 3,
                    Title = "Footer logo centres on mobile view",
                    Priority = 4,
                    Precondition = "Must be viewing on a mobile device.",
                    Step = "Load the page. Inspect the footer.",
                    Status = ""
                }
            );

            context.Users.AddOrUpdate(x => x.Id,
                new User()
                {
                    Id = 1,
                    Forename = "Andrew",
                    Surname = "Dick",
                    Email = "andrew.dick@cohaesus.co.uk"
                },
                new User()
                {
                    Id = 2,
                    Forename = "Matt",
                    Surname = "Meckes",
                    Email = "matt.meckes@cohaesus.co.uk"
                },
                new User()
                {
                    Id = 3,
                    Forename = "Philip",
                    Surname = "Beaman",
                    Email = "philip.beaman@cohaesus.co.uk"
                }
            );
        }
    }
}
