namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatetableBankInfo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BankInfoes", "BankId", "dbo.Banks");
            DropIndex("dbo.BankInfoes", new[] { "BankId" });
            AddColumn("dbo.BankInfoes", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BankInfoes", "BankNumber", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BankInfoes", "BankBrand", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.BankInfoes", "BankId", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.BankInfoes", "BankId");
            AddForeignKey("dbo.BankInfoes", "BankId", "dbo.Banks", "BankId", cascadeDelete: true);
            DropColumn("dbo.BankInfoes", "BankName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BankInfoes", "BankName", c => c.String(maxLength: 100));
            DropForeignKey("dbo.BankInfoes", "BankId", "dbo.Banks");
            DropIndex("dbo.BankInfoes", new[] { "BankId" });
            AlterColumn("dbo.BankInfoes", "BankId", c => c.String(maxLength: 50));
            AlterColumn("dbo.BankInfoes", "BankBrand", c => c.String(maxLength: 200));
            AlterColumn("dbo.BankInfoes", "BankNumber", c => c.String(maxLength: 50));
            DropColumn("dbo.BankInfoes", "CreatedDate");
            CreateIndex("dbo.BankInfoes", "BankId");
            AddForeignKey("dbo.BankInfoes", "BankId", "dbo.Banks", "BankId");
        }
    }
}
