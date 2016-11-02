namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCustomerType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerStatus",
                c => new
                    {
                        CustomerStatusId = c.String(nullable: false, maxLength: 100),
                        CustomerStatusName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CustomerStatusId);
            
            CreateTable(
                "dbo.CustomerTypes",
                c => new
                    {
                        CustomerTypeId = c.String(nullable: false, maxLength: 100),
                        CustomerTypeName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CustomerTypeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerTypes");
            DropTable("dbo.CustomerStatus");
        }
    }
}
