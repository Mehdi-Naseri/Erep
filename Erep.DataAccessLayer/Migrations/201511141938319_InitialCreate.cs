namespace Erep.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Erep.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Message = c.String(nullable: false, maxLength: 1000),
                        AttachmentFileName = c.String(maxLength: 100),
                        AttachmentFile = c.Binary(),
                        Email = c.String(maxLength: 255),
                        MessageDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Management.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MessageTitle = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Identity.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "Identity.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("Identity.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "Erep.Scammer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 500),
                        ReportedBy = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Identity.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 7, storeType: "datetime2"),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "Identity.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Identity.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("Identity.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Management.WebsiteVisitor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HostAddress = c.String(nullable: false),
                        HostName = c.String(nullable: false),
                        Browser = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        UrlReferrer = c.String(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Identity.AspNetUserRoles", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserLogins", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserClaims", "UserId", "Identity.AspNetUsers");
            DropForeignKey("Identity.AspNetUserRoles", "RoleId", "Identity.AspNetRoles");
            DropIndex("Identity.AspNetUserLogins", new[] { "UserId" });
            DropIndex("Identity.AspNetUserClaims", new[] { "UserId" });
            DropIndex("Identity.AspNetUsers", "UserNameIndex");
            DropIndex("Identity.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("Identity.AspNetUserRoles", new[] { "UserId" });
            DropIndex("Identity.AspNetRoles", "RoleNameIndex");
            DropTable("Management.WebsiteVisitor");
            DropTable("Identity.AspNetUserLogins");
            DropTable("Identity.AspNetUserClaims");
            DropTable("Identity.AspNetUsers");
            DropTable("Erep.Scammer");
            DropTable("Identity.AspNetUserRoles");
            DropTable("Identity.AspNetRoles");
            DropTable("Management.Log");
            DropTable("Erep.Contact");
        }
    }
}
