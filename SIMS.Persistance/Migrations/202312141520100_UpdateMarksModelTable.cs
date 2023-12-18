namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMarksModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Marks", "Bangla", c => c.String());
            AddColumn("dbo.Marks", "Bangla2", c => c.String());
            AddColumn("dbo.Marks", "Math", c => c.String());
            AddColumn("dbo.Marks", "English", c => c.String());
            AddColumn("dbo.Marks", "English2", c => c.String());
            AddColumn("dbo.Marks", "GeneralScience", c => c.String());
            AddColumn("dbo.Marks", "SocialScience", c => c.String());
            AddColumn("dbo.Marks", "BnagladeshWorld", c => c.String());
            AddColumn("dbo.Marks", "IslamicStudies", c => c.String());
            AddColumn("dbo.Marks", "ICT", c => c.String());
            AddColumn("dbo.Marks", "AgricultureStudies", c => c.String());
            AddColumn("dbo.Marks", "Science", c => c.String());
            AddColumn("dbo.Marks", "Physics", c => c.String());
            AddColumn("dbo.Marks", "Chemistry", c => c.String());
            AddColumn("dbo.Marks", "Biology", c => c.String());
            AddColumn("dbo.Marks", "HigherMath", c => c.String());
            AddColumn("dbo.Marks", "BusinessStudies", c => c.String());
            AddColumn("dbo.Marks", "Accountiong", c => c.String());
            AddColumn("dbo.Marks", "FinanceBanking", c => c.String());
            AddColumn("dbo.Marks", "History", c => c.String());
            AddColumn("dbo.Marks", "Geography", c => c.String());
            AddColumn("dbo.Marks", "PoliticalScience", c => c.String());
            AddColumn("dbo.Marks", "Economics", c => c.String());
            AddColumn("dbo.Marks", "Sociology", c => c.String());
            AddColumn("dbo.Marks", "OptionalSubject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Marks", "OptionalSubject");
            DropColumn("dbo.Marks", "Sociology");
            DropColumn("dbo.Marks", "Economics");
            DropColumn("dbo.Marks", "PoliticalScience");
            DropColumn("dbo.Marks", "Geography");
            DropColumn("dbo.Marks", "History");
            DropColumn("dbo.Marks", "FinanceBanking");
            DropColumn("dbo.Marks", "Accountiong");
            DropColumn("dbo.Marks", "BusinessStudies");
            DropColumn("dbo.Marks", "HigherMath");
            DropColumn("dbo.Marks", "Biology");
            DropColumn("dbo.Marks", "Chemistry");
            DropColumn("dbo.Marks", "Physics");
            DropColumn("dbo.Marks", "Science");
            DropColumn("dbo.Marks", "AgricultureStudies");
            DropColumn("dbo.Marks", "ICT");
            DropColumn("dbo.Marks", "IslamicStudies");
            DropColumn("dbo.Marks", "BnagladeshWorld");
            DropColumn("dbo.Marks", "SocialScience");
            DropColumn("dbo.Marks", "GeneralScience");
            DropColumn("dbo.Marks", "English2");
            DropColumn("dbo.Marks", "English");
            DropColumn("dbo.Marks", "Math");
            DropColumn("dbo.Marks", "Bangla2");
            DropColumn("dbo.Marks", "Bangla");
        }
    }
}
