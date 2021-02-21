namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useremail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Makes", "currentUserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makes", "currentUserEmail");
        }
    }
}
