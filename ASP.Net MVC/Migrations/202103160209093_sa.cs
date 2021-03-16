namespace ASP.Net_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTimeOffset(nullable: false, precision: 7),
                        Division_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Divisions", t => t.Division_Id, cascadeDelete: true)
                .Index(t => t.Division_Id);
            
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Department_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id, cascadeDelete: true)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Departments", "Division_Id", "dbo.Divisions");
            DropIndex("dbo.Employees", new[] { "Department_Id" });
            DropIndex("dbo.Departments", new[] { "Division_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Divisions");
            DropTable("dbo.Departments");
        }
    }
}
