using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Error404NotLost_DAL.Entities;

namespace Error404NotLost_DAL
{
    public class Error404NotFoundDbContext : IdentityDbContext
    {
        public Error404NotFoundDbContext(DbContextOptions<Error404NotFoundDbContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
    }
}
