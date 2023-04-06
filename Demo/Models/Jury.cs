using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Jury : User
    {
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set;}
    }
}
