namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelsetup1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropColumn("dbo.Models", "MakeId");
            DropColumn("dbo.Models", "MakeName");
            DropColumn("dbo.Models", "SelectedMakeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Models", "SelectedMakeId", c => c.Int(nullable: false));
            AddColumn("dbo.Models", "MakeName", c => c.String());
            AddColumn("dbo.Models", "MakeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "MakeId");
            AddForeignKey("dbo.Models", "MakeId", "dbo.Makes", "MakeId", cascadeDelete: true);
        }
    }
}
