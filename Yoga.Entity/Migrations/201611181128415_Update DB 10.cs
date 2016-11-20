namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "TaxCode", c => c.String());
            AddColumn("dbo.ClassInfoes", "BillCompany", c => c.String());
            AddColumn("dbo.ClassInfoes", "BillAddress", c => c.String());
            AddColumn("dbo.ClassInfoes", "Note", c => c.String());
            DropColumn("dbo.Customers", "TaxCode");
            DropColumn("dbo.Customers", "BillCompany");
            DropColumn("dbo.Customers", "BillAddress");
            DropColumn("dbo.Orders", "IsMakeBill");
            DropColumn("dbo.Orders", "TaxCode");
            DropColumn("dbo.Orders", "BillCompany");
            DropColumn("dbo.Orders", "BillAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "BillAddress", c => c.String());
            AddColumn("dbo.Orders", "BillCompany", c => c.String());
            AddColumn("dbo.Orders", "TaxCode", c => c.String());
            AddColumn("dbo.Orders", "IsMakeBill", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "BillAddress", c => c.String());
            AddColumn("dbo.Customers", "BillCompany", c => c.String());
            AddColumn("dbo.Customers", "TaxCode", c => c.String());
            DropColumn("dbo.ClassInfoes", "Note");
            DropColumn("dbo.ClassInfoes", "BillAddress");
            DropColumn("dbo.ClassInfoes", "BillCompany");
            DropColumn("dbo.ClassInfoes", "TaxCode");
        }
    }
}
