using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Error404NotLost_DAL.Entities;

namespace Error404NotLost_DAL
{
    public class Error404NotLostDbContext : IdentityDbContext
    {
        public Error404NotLostDbContext(DbContextOptions<Error404NotLostDbContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tutoring> Tutorings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SchoolClass>()
                .HasIndex(sc => sc.Name)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .HasIndex(l => l.Name)
                .IsUnique();


        }
    }
}
