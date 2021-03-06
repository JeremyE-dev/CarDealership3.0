namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicletbles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleId = c.Int(nullable: false, identity: true),
                        BodyStyleName = c.String(),
                    })
                .PrimaryKey(t => t.BodyStyleId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Interiors",
                c => new
                    {
                        InteriorId = c.Int(nullable: false, identity: true),
                        InteriorName = c.String(),
                    })
                .PrimaryKey(t => t.InteriorId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        TransmissionName = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        VehicleTypeName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Interiors");
            DropTable("dbo.Colors");
            DropTable("dbo.BodyStyles");
        }
    }
}
