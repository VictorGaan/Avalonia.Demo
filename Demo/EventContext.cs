using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class EventContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Jury> Juries { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<Organizer> Organizer { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<User> Users { get; set; }
        public EventContext() { }
        public EventContext(DbContextOptions<EventContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Server=localhost;Port=5432;Database=Events;User Id=postgres;Password=12()HG34");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseIdentityByDefaultColumns();
        }
    }
}
