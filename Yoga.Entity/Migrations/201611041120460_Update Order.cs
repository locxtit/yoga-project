namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OperatorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "OperatorId");
            AddForeignKey("dbo.Orders", "OperatorId", "dbo.Operators", "OperatorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OperatorId", "dbo.Operators");
            DropIndex("dbo.Orders", new[] { "OperatorId" });
            DropColumn("dbo.Orders", "OperatorId");
        }
    }
}
