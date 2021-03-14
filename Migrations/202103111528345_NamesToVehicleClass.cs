namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesToVehicleClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "MakeName", c => c.String());
            AddColumn("dbo.Vehicles", "VehicleModelName", c => c.String());
            AddColumn("dbo.Vehicles", "TransmissionName", c => c.String());
            AddColumn("dbo.Vehicles", "ColorName", c => c.String());
            AddColumn("dbo.Vehicles", "InteriorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "InteriorName");
            DropColumn("dbo.Vehicles", "ColorName");
            DropColumn("dbo.Vehicles", "TransmissionName");
            DropColumn("dbo.Vehicles", "VehicleModelName");
            DropColumn("dbo.Vehicles", "MakeName");
        }
    }
}
