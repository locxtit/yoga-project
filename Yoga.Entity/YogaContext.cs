using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class YogaContext : DbContext
    {

        public YogaContext()
            : base("name=YogaContext")
        {
        }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<CustomerStatus> CustomerStatuses { get; set; }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<BankInfo> BankInfos { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ClassInfo> ClassInfos { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<EventJoiner> EventJoiners { get; set; }

        public DbSet<OperatorType> OperatorTypes { get; set; }

        public DbSet<Operator> Operators { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<OrderService> OrderServices { get; set; }

        public DbSet<OrderInternal> OrderInternals { get; set; }

        public DbSet<Notify> Notifies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
