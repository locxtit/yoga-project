namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableNotify1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifies",
                c => new
                    {
                        NotityId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 400),
                        CreatedDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        StatusId = c.String(maxLength: 50),
                        OperatorAddId = c.Int(nullable: false),
                        OperatorRecieptId = c.Int(),
                    })
                .PrimaryKey(t => t.NotityId)
                .ForeignKey("dbo.Operators", t => t.OperatorAddId, cascadeDelete: true)
                .ForeignKey("dbo.Operators", t => t.OperatorRecieptId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.OperatorAddId)
                .Index(t => t.OperatorRecieptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifies", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Notifies", "OperatorRecieptId", "dbo.Operators");
            DropForeignKey("dbo.Notifies", "OperatorAddId", "dbo.Operators");
            DropIndex("dbo.Notifies", new[] { "OperatorRecieptId" });
            DropIndex("dbo.Notifies", new[] { "OperatorAddId" });
            DropIndex("dbo.Notifies", new[] { "StatusId" });
            DropTable("dbo.Notifies");
        }
    }
}
