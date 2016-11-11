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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trails", "GiftId", "dbo.Gifts");
            DropForeignKey("dbo.Trails", "CreatorUserId", "dbo.AbpUsers");
            DropIndex("dbo.Trails", new[] { "GiftId" });
            DropIndex("dbo.Trails", new[] { "CreatorUserId" });
            DropTable("dbo.Trails");
        }
    }
}
