namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB14 : DbMigration
    {
        public override void Up()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_Email", newName: "IX_OrderCode");
            AlterColumn("dbo.Orders", "ContactEmail", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ContactEmail", c => c.String(nullable: false, maxLength: 100));
            RenameIndex(table: "dbo.Orders", name: "IX_OrderCode", newName: "IX_Email");
        }
    }
}
