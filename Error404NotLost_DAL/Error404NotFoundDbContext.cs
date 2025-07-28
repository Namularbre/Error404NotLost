using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Error404NotLost_DAL
{
    public class Error404NotFoundDbContext : IdentityDbContext
    {
        public Error404NotFoundDbContext(DbContextOptions<Error404NotFoundDbContext> options)
            : base(options)
        {
        }
    }
}
