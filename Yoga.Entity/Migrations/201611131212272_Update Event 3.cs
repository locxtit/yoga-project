namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEvent3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankInfoes", "BankName", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Events", "OrganizerName", c => c.String(maxLength: 200));
            AddColumn("dbo.Events", "OrganizerPhone", c => c.String(maxLength: 12));
            AddColumn("dbo.Events", "OrganizerEmail", c => c.String(maxLength: 100));
            AddColumn("dbo.Events", "OrganizerAddress", c => c.String(maxLength: 200));
            AddColumn("dbo.Events", "OperatorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "OperatorId");
            AddForeignKey("dbo.Events", "OperatorId", "dbo.Operators", "OperatorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "OperatorId", "dbo.Operators");
            DropIndex("dbo.Events", new[] { "OperatorId" });
            DropColumn("dbo.Events", "OperatorId");
            DropColumn("dbo.Events", "OrganizerAddress");
            DropColumn("dbo.Events", "OrganizerEmail");
            DropColumn("dbo.Events", "OrganizerPhone");
            DropColumn("dbo.Events", "OrganizerName");
            DropColumn("dbo.BankInfoes", "BankName");
        }
    }
}
