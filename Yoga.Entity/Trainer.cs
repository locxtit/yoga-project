using System;
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

        [StringLength(100)]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Index("IX_Email", 1, IsUnique = true)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(200)]
        public string Experience { get; set; }

        [StringLength(200)]
        public string Subject { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Status Status { get; set; }
    }
}
