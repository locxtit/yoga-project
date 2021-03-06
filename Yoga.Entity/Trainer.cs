﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Trainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainerId { get; set; }

        [StringLength(200)]
        public string TrainerName { get; set; }

        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$|^(\d{11})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [StringLength(400)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Experience { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }

        public int? ProvinceId { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        [StringLength(4000)]
        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Status Status { get; set; }

        public virtual Province Province { get; set; }

        public virtual ICollection<BankInfo> BankInfos { get; set; }
    }
}
