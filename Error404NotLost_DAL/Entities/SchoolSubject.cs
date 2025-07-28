using Microsoft.AspNetCore.Identity;

namespace Error404NotLost_DAL.Entities
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AuthorId { get; set; } = null!;
        public IdentityUser Author { get; set; } = null!;
    }
}
