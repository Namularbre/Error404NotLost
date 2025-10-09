using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Error404NotLost_DAL.Entities
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<SchoolSubject> Subjects { get; set; } = new List<SchoolSubject>();
        public string AuthorId { get; set; } = null!;
        public IdentityUser Author { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
