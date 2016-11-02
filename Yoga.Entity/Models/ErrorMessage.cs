using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity.Models
{
    public class ErrorMessage
    {
        public bool Result { get; set; }
        public string ErrorString { get; set; }
        public string SystemMessage { get; set; }
    }
}
