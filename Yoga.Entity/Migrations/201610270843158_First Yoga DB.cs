namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstYogaDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(),
                        StatusId = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.String(nullable: false, maxLength: 128),
                        Statusname = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Status");
            DropTable("dbo.Provinces");
        }
    }
}
