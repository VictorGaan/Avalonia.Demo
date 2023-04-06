using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Organizer : User
    {
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
