namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrderInternal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderInternals",
                c => new
                    {
                        OrderInternalId = c.Int(nullable: false, identity: true),
                        OperatorId = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        Note = c.String(maxLength: 1000),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderInternalId)
                .ForeignKey("dbo.Operators", t => t.OperatorId, cascadeDelete: true)
                .Index(t => t.OperatorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderInternals", "OperatorId", "dbo.Operators");
            DropIndex("dbo.OrderInternals", new[] { "OperatorId" });
            DropTable("dbo.OrderInternals");
        }
    }
}
