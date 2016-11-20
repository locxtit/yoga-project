namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB6 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Trainers", new[] { "Email" });
            AlterColumn("dbo.Trainers", "Email", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "Email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Trainers", "Email", unique: true);
        }
    }
}
