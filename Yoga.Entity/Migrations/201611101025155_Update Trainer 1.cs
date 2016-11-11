namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrainer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "CreatedDate");
        }
    }
}
