namespace ASP.Net_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFKDivision : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Division_Id", "dbo.Divisions");
            DropIndex("dbo.Departments", new[] { "Division_Id" });
            DropColumn("dbo.Departments", "Division_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Division_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "Division_Id");
            AddForeignKey("dbo.Departments", "Division_Id", "dbo.Divisions", "Id", cascadeDelete: true);
        }
    }
}
