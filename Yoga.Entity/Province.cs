using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Province
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProvinceId { get; set; }

        [StringLength(100)]
        public string ProvinceName { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
