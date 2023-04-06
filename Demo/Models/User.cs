﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public int? CityId { get; set; }
        public int RoleId { get; set; }
        public virtual City? City { get; set; }
        public virtual Role Role { get; set; }

    }
}
