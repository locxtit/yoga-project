namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "Email" });
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Customers", "Email", unique: true);
        }
    }
}
