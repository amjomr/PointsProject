namespace PointsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auctions",
                c => new
                    {
                        AuctionId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Title = c.String(maxLength: 128),
                        Description = c.String(maxLength: 50),
                        HighestBid = c.Int(nullable: false),
                        Image = c.Binary(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AuctionId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        TotalPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserAuctions",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Auction_AuctionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Auction_AuctionId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Auctions", t => t.Auction_AuctionId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Auction_AuctionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAuctions", "Auction_AuctionId", "dbo.Auctions");
            DropForeignKey("dbo.UserAuctions", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserAuctions", new[] { "Auction_AuctionId" });
            DropIndex("dbo.UserAuctions", new[] { "User_UserId" });
            DropTable("dbo.UserAuctions");
            DropTable("dbo.Users");
            DropTable("dbo.Auctions");
        }
    }
}
