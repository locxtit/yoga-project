namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        Price = c.Double(nullable: false),
                        StatusId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "StatusId", "dbo.Status");
            DropIndex("dbo.Services", new[] { "StatusId" });
            DropTable("dbo.Services");
        }
    }
}
