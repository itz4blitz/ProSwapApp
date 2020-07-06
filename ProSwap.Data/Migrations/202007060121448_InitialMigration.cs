namespace ProSwap.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 125),
                        Content = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CurrencyName = c.String(),
                        CurrencyPriceUSD = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Offer",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false, maxLength: 3000),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            DropTable("dbo.Threads");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false, maxLength: 3000),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ThreadID);
            
            DropForeignKey("dbo.Offer", "GameId", "dbo.Game");
            DropIndex("dbo.Offer", new[] { "GameId" });
            DropTable("dbo.Offer");
            DropTable("dbo.Game");
            DropTable("dbo.Comment");
        }
    }
}
