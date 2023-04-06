using System.Collections.Generic;

namespace Demo.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
