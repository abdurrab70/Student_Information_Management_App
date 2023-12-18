namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateResultPointResultTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "PointResult", c => c.String());
            DropColumn("dbo.Marks", "Result");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Marks", "Result", c => c.String());
            DropColumn("dbo.Marks", "PointResult");
        }
    }
}
