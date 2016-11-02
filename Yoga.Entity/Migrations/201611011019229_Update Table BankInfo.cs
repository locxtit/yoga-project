namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableBankInfo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "Bank_BankId", "dbo.Banks");
            DropIndex("dbo.Trainers", new[] { "Bank_BankId" });
            CreateTable(
                "dbo.BankInfoes",
                c => new
                    {
                        BankInfoId = c.Int(nullable: false, identity: true),
                        BankNumber = c.String(maxLength: 50),
                        BankName = c.String(maxLength: 100),
                        BankBrand = c.String(maxLength: 200),
                        IsMain = c.Boolean(nullable: false),
                        StatusId = c.String(maxLength: 50),
                        BankId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BankInfoId)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.BankId);
            
            DropColumn("dbo.Trainers", "Bank_BankId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Bank_BankId", c => c.String(maxLength: 50));
            DropForeignKey("dbo.BankInfoes", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BankInfoes", "BankId", "dbo.Banks");
            DropIndex("dbo.BankInfoes", new[] { "BankId" });
            DropIndex("dbo.BankInfoes", new[] { "StatusId" });
            DropTable("dbo.BankInfoes");
            CreateIndex("dbo.Trainers", "Bank_BankId");
            AddForeignKey("dbo.Trainers", "Bank_BankId", "dbo.Banks", "BankId");
        }
    }
}
