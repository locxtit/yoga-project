namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOperator1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Operators", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Operators", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Operators", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Operators", "Phone", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operators", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Operators", "Email", c => c.String(maxLength: 200));
            AlterColumn("dbo.Operators", "Password", c => c.String(maxLength: 100));
            AlterColumn("dbo.Operators", "Username", c => c.String(maxLength: 100));
        }
    }
}
