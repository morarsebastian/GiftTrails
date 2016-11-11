namespace GiftTrails.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GooglePlaceToTrail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trails", "GooglePlaceId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trails", "GooglePlaceId");
        }
    }
}
