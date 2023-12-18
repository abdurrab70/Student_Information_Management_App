namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateResultMarksEntryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentEntryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Section = c.String(),
                        Session = c.String(),
                        Grade = c.String(),
                        Add = c.String(),
                        CheckFailure = c.String(),
                        Result = c.String(),
                        Calculate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.StudentEntries", t => t.StudentEntryId, cascadeDelete: false)
                .Index(t => t.StudentEntryId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "StudentEntryId", "dbo.StudentEntries");
            DropForeignKey("dbo.Marks", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Marks", new[] { "DepartmentId" });
            DropIndex("dbo.Marks", new[] { "StudentEntryId" });
            DropTable("dbo.Marks");
        }
    }
}
