namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicletypenametovehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehicleTypeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "VehicleTypeName");
        }
    }
}
