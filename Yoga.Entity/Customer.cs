using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(12)]
        public string SecondaryPhone { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string CustomerTypeId { get; set; }

        [StringLength(100)]
        public string CustomerStatusId { get; set; }

        [StringLength(400)]
        public string Note { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public CustomerStatus CustomerStatus { get; set; }

        public CustomerType CustomerType { get; set; }

        public Status Status { get; set; }
    }
}
