namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonenumberisstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Phone", c => c.Int());
        }
    }
}
