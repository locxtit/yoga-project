namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEvent5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "CountMember", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "CountMember");
        }
    }
}
