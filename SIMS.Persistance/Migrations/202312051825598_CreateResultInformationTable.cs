namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateResultInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentEntryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        BoardRoll = c.String(),
                        RegistrationNo = c.String(),
                        Section = c.String(),
                        Result = c.String(),
                        ActiveStatus = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Session = c.String(),
                        SubjectId = c.String(),
                        Remark = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.StudentEntries", t => t.StudentEntryId, cascadeDelete: false)
                .Index(t => t.StudentEntryId)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultInformations", "StudentEntryId", "dbo.StudentEntries");
            DropForeignKey("dbo.ResultInformations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.ResultInformations", new[] { "DepartmentId" });
            DropIndex("dbo.ResultInformations", new[] { "StudentEntryId" });
            DropTable("dbo.ResultInformations");
        }
    }
}
