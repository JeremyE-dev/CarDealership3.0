namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bodystylenametovehicle : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "BodyStyle_BodyStyleId", "dbo.BodyStyles");
            DropIndex("dbo.Vehicles", new[] { "BodyStyle_BodyStyleId" });
            RenameColumn(table: "dbo.Vehicles", name: "BodyStyle_BodyStyleId", newName: "BodyStyleId");
            AddColumn("dbo.Vehicles", "BodyStyleName", c => c.String());
            AlterColumn("dbo.Vehicles", "BodyStyleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "BodyStyleId");
            AddForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles", "BodyStyleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles");
            DropIndex("dbo.Vehicles", new[] { "BodyStyleId" });
            AlterColumn("dbo.Vehicles", "BodyStyleId", c => c.Int());
            DropColumn("dbo.Vehicles", "BodyStyleName");
            RenameColumn(table: "dbo.Vehicles", name: "BodyStyleId", newName: "BodyStyle_BodyStyleId");
            CreateIndex("dbo.Vehicles", "BodyStyle_BodyStyleId");
            AddForeignKey("dbo.Vehicles", "BodyStyle_BodyStyleId", "dbo.BodyStyles", "BodyStyleId");
        }
    }
}
