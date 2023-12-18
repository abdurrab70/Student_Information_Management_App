namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOperationModuleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "ClassId", c => c.Int(nullable: false));
            DropColumn("dbo.Marks", "StudentEntryId");
            DropColumn("dbo.Marks", "Add");
            DropColumn("dbo.Marks", "Calculate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marks", "Calculate", c => c.String());
            AddColumn("dbo.Marks", "Add", c => c.String());
            AddColumn("dbo.Marks", "StudentEntryId", c => c.Int(nullable: false));
            DropColumn("dbo.Marks", "ClassId");
        }
    }
}
