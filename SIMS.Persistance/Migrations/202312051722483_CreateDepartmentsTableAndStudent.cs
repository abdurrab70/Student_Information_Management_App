namespace SIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDepartmentsTableAndStudent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PresentAddress = c.String(),
                        PermanantAddress = c.String(),
                        Nationality = c.String(),
                        Gender = c.String(),
                        BloodGroup = c.String(),
                        Religion = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Section = c.String(),
                        Remark = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        FatherPhoneNo = c.String(),
                        MotherPhoneNo = c.String(),
                        FatherEmail = c.String(),
                        NidBirthCertificate = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentEntries", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.StudentEntries", new[] { "DepartmentId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentEntries");
            DropTable("dbo.Departments");
        }
    }
}
