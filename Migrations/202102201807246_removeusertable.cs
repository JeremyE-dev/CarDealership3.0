namespace CarDealership2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeusertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Makes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Models", "UserId", "dbo.Users");
            DropIndex("dbo.Makes", new[] { "UserId" });
            DropIndex("dbo.Models", new[] { "UserId" });
            DropColumn("dbo.Makes", "UserId");
            DropColumn("dbo.Models", "UserId");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Role = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Models", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Makes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Models", "UserId");
            CreateIndex("dbo.Makes", "UserId");
            AddForeignKey("dbo.Models", "UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Makes", "UserId", "dbo.Users", "UserId");
        }
    }
}
