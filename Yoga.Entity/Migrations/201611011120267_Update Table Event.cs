namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventJoiners",
                c => new
                    {
                        EventJoinerId = c.Int(nullable: false, identity: true),
                        TrainerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Note = c.String(maxLength: 1000),
                        Opinion = c.String(maxLength: 1000),
                        EventId = c.Int(nullable: false),
                        StatusId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EventJoinerId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId)
                .Index(t => t.EventId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Description = c.String(maxLength: 400),
                        ContentDetail = c.String(maxLength: 4000),
                        EventTypeId = c.String(maxLength: 50),
                        StatusId = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventTypes", t => t.EventTypeId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.EventTypeId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeId = c.String(nullable: false, maxLength: 50),
                        EventTypeName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.EventTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventJoiners", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.EventJoiners", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EventJoiners", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Events", "EventTypeId", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "StatusId" });
            DropIndex("dbo.Events", new[] { "EventTypeId" });
            DropIndex("dbo.EventJoiners", new[] { "StatusId" });
            DropIndex("dbo.EventJoiners", new[] { "EventId" });
            DropIndex("dbo.EventJoiners", new[] { "TrainerId" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
            DropTable("dbo.EventJoiners");
        }
    }
}
