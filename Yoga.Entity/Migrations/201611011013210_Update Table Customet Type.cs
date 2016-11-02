namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTableCustometType : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Trainers", name: "BankId", newName: "Bank_BankId");
            RenameIndex(table: "dbo.Trainers", name: "IX_BankId", newName: "IX_Bank_BankId");
            DropColumn("dbo.Trainers", "BankNumber");
            DropColumn("dbo.Trainers", "BankName");
            DropColumn("dbo.Trainers", "BankBrand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "BankBrand", c => c.String(maxLength: 200));
            AddColumn("dbo.Trainers", "BankName", c => c.String(maxLength: 100));
            AddColumn("dbo.Trainers", "BankNumber", c => c.String(maxLength: 50));
            RenameIndex(table: "dbo.Trainers", name: "IX_Bank_BankId", newName: "IX_BankId");
            RenameColumn(table: "dbo.Trainers", name: "Bank_BankId", newName: "BankId");
        }
    }
}
