namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class today : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "MakeId", c => c.Int());
            AddColumn("dbo.Models", "MakeName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Models", "MakeName");
            DropColumn("dbo.Models", "MakeId");
        }
    }
}
