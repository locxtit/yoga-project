namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTrainertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banks",
                c => new
                    {
                        BankId = c.String(nullable: false, maxLength: 128),
                        BankName = c.String(),
                    })
                .PrimaryKey(t => t.BankId);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        TrainerName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Experience = c.String(),
                        Subject = c.String(),
                        BankId = c.String(maxLength: 128),
                        BankNumber = c.String(),
                        BankName = c.String(),
                        BankBrand = c.String(),
                        StatusId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrainerId)
                .ForeignKey("dbo.Banks", t => t.BankId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.BankId)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Trainers", "BankId", "dbo.Banks");
            DropIndex("dbo.Trainers", new[] { "StatusId" });
            DropIndex("dbo.Trainers", new[] { "BankId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Banks");
        }
    }
}
