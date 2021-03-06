﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [StringLength(15)]
        [Index("IX_OrderCode", 1, IsUnique = true)]
        public string OrderCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int OperatorId { get; set; }

        [StringLength(100)]
        [Required]
        public string ContactName { get; set; }

        [StringLength(100)]
        //[Required]
        public string ContactEmail { get; set; }

        [StringLength(12)]
        [Required]  
        public string CustomerPhone { get; set; }

        [StringLength(200)]
        public string ContactAddress { get; set; }

        public int NumOfDays { get; set; }

        public double Price { get; set; }

        public double PriceForTrainer { get; set; }

        public double TotalPaid { get; set; }

        public double TotalPaidForTrainer { get; set; }

        [StringLength(50)]
        public string OrderStatusId { get; set; }

        public int ClassInfoId { get; set; }

        [StringLength(4000)]
        public string Note { get; set; }

        public virtual ClassInfo ClassInfo { get; set; }

        public virtual Operator Operator { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public string TaxCode { get; set; }

        public string BillCompany { get; set; }

        public string BillAddress { get; set; }
    }
}
