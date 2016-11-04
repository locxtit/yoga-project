namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOperator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "OperatorId", "dbo.Operators");
            DropIndex("dbo.Orders", new[] { "OperatorId" });
            AddColumn("dbo.Operators", "Phone", c => c.String(maxLength: 12));
            AddColumn("dbo.Operators", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OperatorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OperatorId", c => c.Int(nullable: false));
            DropColumn("dbo.Operators", "CreatedDate");
            DropColumn("dbo.Operators", "Phone");
            CreateIndex("dbo.Orders", "OperatorId");
            AddForeignKey("dbo.Orders", "OperatorId", "dbo.Operators", "OperatorId", cascadeDelete: true);
        }
    }
}
