namespace TestRailMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserController : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserProjects", newName: "ProjectUsers");
            DropPrimaryKey("dbo.ProjectUsers");
            AddPrimaryKey("dbo.ProjectUsers", new[] { "Project_Id", "User_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ProjectUsers");
            AddPrimaryKey("dbo.ProjectUsers", new[] { "User_Id", "Project_Id" });
            RenameTable(name: "dbo.ProjectUsers", newName: "UserProjects");
        }
    }
}
