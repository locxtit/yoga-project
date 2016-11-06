namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOperatorRemoveUserName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Operators", "Email", unique: true);
            DropColumn("dbo.Operators", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operators", "Username", c => c.String(nullable: false, maxLength: 100));
            DropIndex("dbo.Operators", new[] { "Email" });
        }
    }
}
