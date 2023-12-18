namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMarkViewModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "MathematicsStatistics", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "MathematicsStatistics");
        }
    }
}
