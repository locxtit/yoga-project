namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "ProvinceId", c => c.Int());
            CreateIndex("dbo.Trainers", "ProvinceId");
            AddForeignKey("dbo.Trainers", "ProvinceId", "dbo.Provinces", "ProvinceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Trainers", new[] { "ProvinceId" });
            DropColumn("dbo.Trainers", "ProvinceId");
        }
    }
}
