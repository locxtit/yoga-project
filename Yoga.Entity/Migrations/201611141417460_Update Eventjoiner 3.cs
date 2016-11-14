namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventjoiner3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EventJoiners", new[] { "TrainerId" });
            DropIndex("dbo.EventJoiners", new[] { "EventId" });
            CreateIndex("dbo.EventJoiners", new[] { "TrainerId", "EventId" }, unique: true, name: "IX_TrainerIdAndEventId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EventJoiners", "IX_TrainerIdAndEventId");
            CreateIndex("dbo.EventJoiners", "EventId");
            CreateIndex("dbo.EventJoiners", "TrainerId");
        }
    }
}
