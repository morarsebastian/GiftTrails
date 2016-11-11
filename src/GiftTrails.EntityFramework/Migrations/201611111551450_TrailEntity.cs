namespace GiftTrails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrailEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 256),
                        CountryName = c.String(nullable: false, maxLength: 256),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 9),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 9),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(nullable: false),
                        GiftId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpUsers", t => t.CreatorUserId, cascadeDelete: true)
                .ForeignKey("dbo.Gifts", t => t.GiftId, cascadeDelete: true)
                .Index(t => t.CreatorUserId)
                .Index(t => t.GiftId);
            
            AddColumn("dbo.Gifts", "CreatorUserId", c => c.Long(nullable: false));
            CreateIndex("dbo.Gifts", "CreatorUserId");
            AddForeignKey("dbo.Gifts", "CreatorUserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trails", "GiftId", "dbo.Gifts");
            DropForeignKey("dbo.Trails", "CreatorUserId", "dbo.AbpUsers");
            DropForeignKey("dbo.Gifts", "CreatorUserId", "dbo.AbpUsers");
            DropIndex("dbo.Trails", new[] { "GiftId" });
            DropIndex("dbo.Trails", new[] { "CreatorUserId" });
            DropIndex("dbo.Gifts", new[] { "CreatorUserId" });
            DropColumn("dbo.Gifts", "CreatorUserId");
            DropTable("dbo.Trails");
        }
    }
}
