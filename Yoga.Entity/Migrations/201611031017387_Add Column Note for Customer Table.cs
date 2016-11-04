namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNoteforCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Note", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Note");
        }
    }
}
