namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResultMarksTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Marks", "StudentEntryId", "dbo.StudentEntries");
            DropIndex("dbo.Marks", new[] { "StudentEntryId" });
            AddColumn("dbo.Marks", "TotalMarks", c => c.String());
            AddColumn("dbo.Marks", "Average", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "Average");
            DropColumn("dbo.Marks", "TotalMarks");
            CreateIndex("dbo.Marks", "StudentEntryId");
            AddForeignKey("dbo.Marks", "StudentEntryId", "dbo.StudentEntries", "Id", cascadeDelete: true);
        }
    }
}
