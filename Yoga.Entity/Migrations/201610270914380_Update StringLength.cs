namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStringLength : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainers", "BankId", "dbo.Banks");
            DropForeignKey("dbo.Provinces", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Trainers", "StatusId", "dbo.Status");
            DropIndex("dbo.Provinces", new[] { "StatusId" });
            DropIndex("dbo.Trainers", new[] { "BankId" });
            DropIndex("dbo.Trainers", new[] { "StatusId" });
            DropPrimaryKey("dbo.Banks");
            DropPrimaryKey("dbo.Status");
            AlterColumn("dbo.Banks", "BankId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Banks", "BankName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Provinces", "ProvinceName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Provinces", "StatusId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Status", "StatusId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Status", "Statusname", c => c.String(maxLength: 100));
            AlterColumn("dbo.Trainers", "TrainerName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Trainers", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Trainers", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Trainers", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.Trainers", "Experience", c => c.String(maxLength: 200));
            AlterColumn("dbo.Trainers", "Subject", c => c.String(maxLength: 20));
            AlterColumn("dbo.Trainers", "BankId", c => c.String(maxLength: 50));
            AlterColumn("dbo.Trainers", "BankNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.Trainers", "BankName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Trainers", "BankBrand", c => c.String(maxLength: 200));
            AlterColumn("dbo.Trainers", "StatusId", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Banks", "BankId");
            AddPrimaryKey("dbo.Status", "StatusId");
            CreateIndex("dbo.Provinces", "StatusId");
            CreateIndex("dbo.Trainers", "BankId");
            CreateIndex("dbo.Trainers", "StatusId");
            AddForeignKey("dbo.Trainers", "BankId", "dbo.Banks", "BankId");
            AddForeignKey("dbo.Provinces", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Trainers", "StatusId", "dbo.Status", "StatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Provinces", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Trainers", "BankId", "dbo.Banks");
            DropIndex("dbo.Trainers", new[] { "StatusId" });
            DropIndex("dbo.Trainers", new[] { "BankId" });
            DropIndex("dbo.Provinces", new[] { "StatusId" });
            DropPrimaryKey("dbo.Status");
            DropPrimaryKey("dbo.Banks");
            AlterColumn("dbo.Trainers", "StatusId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Trainers", "BankBrand", c => c.String());
            AlterColumn("dbo.Trainers", "BankName", c => c.String());
            AlterColumn("dbo.Trainers", "BankNumber", c => c.String());
            AlterColumn("dbo.Trainers", "BankId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Trainers", "Subject", c => c.String());
            AlterColumn("dbo.Trainers", "Experience", c => c.String());
            AlterColumn("dbo.Trainers", "Address", c => c.String());
            AlterColumn("dbo.Trainers", "Email", c => c.String());
            AlterColumn("dbo.Trainers", "Phone", c => c.String());
            AlterColumn("dbo.Trainers", "TrainerName", c => c.String());
            AlterColumn("dbo.Status", "Statusname", c => c.String());
            AlterColumn("dbo.Status", "StatusId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Provinces", "StatusId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Provinces", "ProvinceName", c => c.String());
            AlterColumn("dbo.Banks", "BankName", c => c.String());
            AlterColumn("dbo.Banks", "BankId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Status", "StatusId");
            AddPrimaryKey("dbo.Banks", "BankId");
            CreateIndex("dbo.Trainers", "StatusId");
            CreateIndex("dbo.Trainers", "BankId");
            CreateIndex("dbo.Provinces", "StatusId");
            AddForeignKey("dbo.Trainers", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Provinces", "StatusId", "dbo.Status", "StatusId");
            AddForeignKey("dbo.Trainers", "BankId", "dbo.Banks", "BankId");
        }
    }
}
