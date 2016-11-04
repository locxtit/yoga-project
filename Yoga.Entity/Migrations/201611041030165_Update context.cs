namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatecontext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "TrainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ClassInfoes", "TrainerId");
            AddForeignKey("dbo.ClassInfoes", "TrainerId", "dbo.Trainers", "TrainerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassInfoes", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.ClassInfoes", new[] { "TrainerId" });
            DropColumn("dbo.ClassInfoes", "TrainerId");
        }
    }
}
