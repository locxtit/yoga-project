namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBankinfo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ContactName", c => c.String(maxLength: 100));
            AddColumn("dbo.Orders", "NumOfDays", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OrderCode", unique: true, name: "IX_Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Orders", "IX_Email");
            DropColumn("dbo.Orders", "NumOfDays");
            DropColumn("dbo.Orders", "ContactName");
        }
    }
}
