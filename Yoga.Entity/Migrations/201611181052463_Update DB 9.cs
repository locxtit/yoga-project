namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "TaxCode", c => c.String());
            AddColumn("dbo.Customers", "BillCompany", c => c.String());
            AddColumn("dbo.Customers", "BillAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BillAddress");
            DropColumn("dbo.Customers", "BillCompany");
            DropColumn("dbo.Customers", "TaxCode");
        }
    }
}
