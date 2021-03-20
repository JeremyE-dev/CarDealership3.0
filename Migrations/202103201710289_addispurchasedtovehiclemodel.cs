namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addispurchasedtovehiclemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "IsPurchased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsPurchased");
        }
    }
}
