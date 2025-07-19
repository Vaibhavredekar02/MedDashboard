namespace MedicalDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MedicalFiles",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FileName = c.String(nullable: false),
                        FileType = c.String(nullable: false),
                        FilePath = c.String(nullable: false),
                        UploadedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(),
                        Phone = c.String(),
                        PasswordHash = c.String(nullable: false),
                        ProfileImagePath = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicalFiles", "UserId", "dbo.Users");
            DropIndex("dbo.MedicalFiles", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.MedicalFiles");
        }
    }
}
