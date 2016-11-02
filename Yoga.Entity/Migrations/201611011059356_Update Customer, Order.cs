namespace Yoga.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassInfoes",
                c => new
                    {
                        ClassInfoId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(maxLength: 100),
                        StatusId = c.String(maxLength: 50),
                        TrainerPrice = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(),
                        NumDaysOfWeek = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassInfoId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 12),
                        SecondaryPhone = c.String(maxLength: 12),
                        Name = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        CustomerTypeId = c.String(maxLength: 100),
                        CustomerStatusId = c.String(maxLength: 100),
                        StatusId = c.String(maxLength: 50),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.CustomerStatus", t => t.CustomerStatusId)
                .ForeignKey("dbo.CustomerTypes", t => t.CustomerTypeId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.CustomerTypeId)
                .Index(t => t.CustomerStatusId)
                .Index(t => t.StatusId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderCode = c.String(maxLength: 10),
                        CreatedDate = c.DateTime(nullable: false),
                        OperatorId = c.Int(nullable: false),
                        ContactEmail = c.String(maxLength: 100),
                        CustomerPhone = c.String(maxLength: 12),
                        ContactAddress = c.String(maxLength: 200),
                        TotalPaid = c.Double(nullable: false),
                        OrderStatusId = c.String(maxLength: 50),
                        ClassInfoId = c.Int(nullable: false),
                        Note = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.ClassInfoes", t => t.ClassInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Operators", t => t.OperatorId, cascadeDelete: true)
                .ForeignKey("dbo.OrderStatus", t => t.OrderStatusId)
                .Index(t => t.OperatorId)
                .Index(t => t.OrderStatusId)
                .Index(t => t.ClassInfoId);
            
            CreateTable(
                "dbo.Operators",
                c => new
                    {
                        OperatorId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        OperatorName = c.String(maxLength: 200),
                        Email = c.String(maxLength: 200),
                        OperatorTypeId = c.String(maxLength: 50),
                        StatusId = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OperatorId)
                .ForeignKey("dbo.OperatorTypes", t => t.OperatorTypeId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.OperatorTypeId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.OperatorTypes",
                c => new
                    {
                        OperatorTypeId = c.String(nullable: false, maxLength: 50),
                        OperatorTypeName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.OperatorTypeId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.String(nullable: false, maxLength: 50),
                        OrderStatusName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            AddColumn("dbo.BankInfoes", "TrainerId", c => c.Int(nullable: false));
            CreateIndex("dbo.BankInfoes", "TrainerId");
            AddForeignKey("dbo.BankInfoes", "TrainerId", "dbo.Trainers", "TrainerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderStatusId", "dbo.OrderStatus");
            DropForeignKey("dbo.Orders", "OperatorId", "dbo.Operators");
            DropForeignKey("dbo.Operators", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Operators", "OperatorTypeId", "dbo.OperatorTypes");
            DropForeignKey("dbo.Orders", "ClassInfoId", "dbo.ClassInfoes");
            DropForeignKey("dbo.ClassInfoes", "StatusId", "dbo.Status");
            DropForeignKey("dbo.ClassInfoes", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Customers", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Customers", "CustomerTypeId", "dbo.CustomerTypes");
            DropForeignKey("dbo.Customers", "CustomerStatusId", "dbo.CustomerStatus");
            DropForeignKey("dbo.BankInfoes", "TrainerId", "dbo.Trainers");
            DropIndex("dbo.Operators", new[] { "StatusId" });
            DropIndex("dbo.Operators", new[] { "OperatorTypeId" });
            DropIndex("dbo.Orders", new[] { "ClassInfoId" });
            DropIndex("dbo.Orders", new[] { "OrderStatusId" });
            DropIndex("dbo.Orders", new[] { "OperatorId" });
            DropIndex("dbo.Customers", new[] { "ProvinceId" });
            DropIndex("dbo.Customers", new[] { "StatusId" });
            DropIndex("dbo.Customers", new[] { "CustomerStatusId" });
            DropIndex("dbo.Customers", new[] { "CustomerTypeId" });
            DropIndex("dbo.ClassInfoes", new[] { "CustomerId" });
            DropIndex("dbo.ClassInfoes", new[] { "StatusId" });
            DropIndex("dbo.BankInfoes", new[] { "TrainerId" });
            DropColumn("dbo.BankInfoes", "TrainerId");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.OperatorTypes");
            DropTable("dbo.Operators");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.ClassInfoes");
        }
    }
}
