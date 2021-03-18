namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehiclemodelincludesIsFeatured : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsFeatured");
        }
    }
}
