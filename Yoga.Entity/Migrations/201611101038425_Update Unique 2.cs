namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUnique2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Trainers", "Email", unique: true);
            CreateIndex("dbo.Customers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Trainers", new[] { "Email" });
            AlterColumn("dbo.Trainers", "Email", c => c.String(maxLength: 100));
        }
    }
}
