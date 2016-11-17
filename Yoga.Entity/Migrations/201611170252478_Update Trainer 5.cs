namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrainer5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Subject", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Subject", c => c.String(maxLength: 20));
        }
    }
}
