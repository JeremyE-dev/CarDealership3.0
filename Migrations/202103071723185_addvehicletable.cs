namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvehicletable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleTypeId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        TransmissionId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        InteriorId = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        VIN = c.String(),
                        MRSP = c.Int(nullable: false),
                        SalePrice = c.Int(nullable: false),
                        Description = c.String(),
                        PhotoPath = c.String(),
                        BodyStyle_BodyStyleId = c.Int(),
                        Make_MakeId = c.Int(),
                        VehicleModel_ModelId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyle_BodyStyleId)
                .ForeignKey("dbo.Colors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.Interiors", t => t.InteriorId, cascadeDelete: true)
                .ForeignKey("dbo.Makes", t => t.Make_MakeId)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.VehicleModel_ModelId)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.TransmissionId)
                .Index(t => t.ColorId)
                .Index(t => t.InteriorId)
                .Index(t => t.BodyStyle_BodyStyleId)
                .Index(t => t.Make_MakeId)
                .Index(t => t.VehicleModel_ModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleModel_ModelId", "dbo.Models");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Vehicles", "Make_MakeId", "dbo.Makes");
            DropForeignKey("dbo.Vehicles", "InteriorId", "dbo.Interiors");
            DropForeignKey("dbo.Vehicles", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Vehicles", "BodyStyle_BodyStyleId", "dbo.BodyStyles");
            DropIndex("dbo.Vehicles", new[] { "VehicleModel_ModelId" });
            DropIndex("dbo.Vehicles", new[] { "Make_MakeId" });
            DropIndex("dbo.Vehicles", new[] { "BodyStyle_BodyStyleId" });
            DropIndex("dbo.Vehicles", new[] { "InteriorId" });
            DropIndex("dbo.Vehicles", new[] { "ColorId" });
            DropIndex("dbo.Vehicles", new[] { "TransmissionId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropTable("dbo.Vehicles");
        }
    }
}
