using Microsoft.EntityFrameworkCore;
using Datalagring.Domain.Entities;

namespace Datalagring.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Registration> Registrations { get; set; }
    }
}