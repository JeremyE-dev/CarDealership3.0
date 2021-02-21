namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodelview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "currentUserEmail", c => c.String());
            AddColumn("dbo.Models", "SelectedMakeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "SelectedMakeId");
            DropColumn("dbo.Models", "currentUserEmail");
        }
    }
}
