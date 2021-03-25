namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedputchasetype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "purchaseType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "purchaseType");
        }
    }
}
