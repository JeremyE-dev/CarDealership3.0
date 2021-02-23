namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmodeldropdown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "MakeId", c => c.Int());
            AddColumn("dbo.Models", "MakeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "MakeName");
            DropColumn("dbo.Models", "MakeId");
        }
    }
}
