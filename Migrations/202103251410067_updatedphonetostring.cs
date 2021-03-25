namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedphonetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchases", "phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "phone", c => c.Int(nullable: false));
        }
    }
}
