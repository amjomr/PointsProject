namespace PointsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class amjad : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAuctions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserAuctions", "Auction_AuctionId", "dbo.Auctions");
            DropIndex("dbo.UserAuctions", new[] { "User_UserId" });
            DropIndex("dbo.UserAuctions", new[] { "Auction_AuctionId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAuctions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAuctions",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Auction_AuctionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Auction_AuctionId });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        TotalPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateIndex("dbo.UserAuctions", "Auction_AuctionId");
            CreateIndex("dbo.UserAuctions", "User_UserId");
            AddForeignKey("dbo.UserAuctions", "Auction_AuctionId", "dbo.Auctions", "AuctionId", cascadeDelete: true);
            AddForeignKey("dbo.UserAuctions", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
