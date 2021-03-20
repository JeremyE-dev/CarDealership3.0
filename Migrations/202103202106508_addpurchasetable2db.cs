namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpurchasetable2db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        phone = c.Int(nullable: false),
                        email = c.String(),
                        street1 = c.String(),
                        street2 = c.String(),
                        city = c.String(),
                        zipcode = c.Int(nullable: false),
                        purchasePrice = c.Int(nullable: false),
                        purchaseState = c.Int(nullable: false),
                        purchaseDate = c.DateTime(nullable: false),
                        purchasedVehicle_VehicleId = c.Int(),
                        salesPerson_Id = c.String(maxLength: 128),
                        vehicle_VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Vehicles", t => t.purchasedVehicle_VehicleId)
                .ForeignKey("dbo.AspNetUsers", t => t.salesPerson_Id)
                .ForeignKey("dbo.Vehicles", t => t.vehicle_VehicleId)
                .Index(t => t.purchasedVehicle_VehicleId)
                .Index(t => t.salesPerson_Id)
                .Index(t => t.vehicle_VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "vehicle_VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Purchases", "salesPerson_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Purchases", "purchasedVehicle_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Purchases", new[] { "vehicle_VehicleId" });
            DropIndex("dbo.Purchases", new[] { "salesPerson_Id" });
            DropIndex("dbo.Purchases", new[] { "purchasedVehicle_VehicleId" });
            DropTable("dbo.Purchases");
        }
    }
}
