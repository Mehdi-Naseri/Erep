namespace Erep.DataLayer.Migrations.ErepMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Message = c.String(nullable: false, maxLength: 2000),
                        AttachmentName = c.String(maxLength: 255),
                        AttachmentFile = c.Binary(),
                        Email = c.String(maxLength: 255),
                        MessageDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GoldPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        LowestPrice = c.Double(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Message = c.String(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scammers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Link = c.String(nullable: false, maxLength: 1000),
                        ReportedBy = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.WebsiteVisitors",
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
            DropTable("dbo.WebsiteVisitors");
            DropTable("dbo.Scammers");
            DropTable("dbo.Logs");
            DropTable("dbo.GoldPrices");
            DropTable("dbo.Contacts");
        }
    }
}
