namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrder4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClassInfoes", "LastestPaymentDate", c => c.DateTime());
            DropColumn("dbo.ClassInfoes", "PaymentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassInfoes", "PaymentDate", c => c.DateTime());
            DropColumn("dbo.ClassInfoes", "LastestPaymentDate");
        }
    }
}
