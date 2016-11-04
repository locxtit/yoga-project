namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomertable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus");
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.Customers", "StatusId", "dbo.Status");
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            DropIndex("dbo.Customers", new[] { "CustomerStatusId" });
            DropIndex("dbo.Customers", new[] { "StatusId" });
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Customers", "CustomerTypeId", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "CustomerStatusId", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Customers", "StatusId", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Customers", "CustomerTypeId");
            CreateIndex("dbo.Customers", "CustomerStatusId");
            CreateIndex("dbo.Customers", "StatusId");
            AddForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus", "CustomerStatusId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "CustomerTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "StatusId", "dbo.Status", "StatusId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus");
            DropIndex("dbo.Customers", new[] { "StatusId" });
            DropIndex("dbo.Customers", new[] { "CustomerStatusId" });
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            AlterColumn("dbo.Customers", "StatusId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customers", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.Customers", "CustomerStatusId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "CustomerTypeId", c => c.String(maxLength: 100));
            AlterColumn("dbo.Customers", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Customers", "Email", c => c.String(maxLength: 100));
            CreateIndex("dbo.Customers", "StatusId");
            CreateIndex("dbo.Customers", "CustomerStatusId");
            CreateIndex("dbo.Customers", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes", "CustomerTypeId");
            AddForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus", "CustomerStatusId");
        }
    }
}
