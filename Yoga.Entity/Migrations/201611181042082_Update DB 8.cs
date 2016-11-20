namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "Note", c => c.String(maxLength: 4000));
            AddColumn("dbo.Orders", "IsMakeBill", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "TaxCode", c => c.String());
            AddColumn("dbo.Orders", "BillCompany", c => c.String());
            AddColumn("dbo.Orders", "BillAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "BillAddress");
            DropColumn("dbo.Orders", "BillCompany");
            DropColumn("dbo.Orders", "TaxCode");
            DropColumn("dbo.Orders", "IsMakeBill");
            DropColumn("dbo.Trainers", "Note");
        }
    }
}
