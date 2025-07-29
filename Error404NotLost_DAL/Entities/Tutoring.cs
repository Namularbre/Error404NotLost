using Microsoft.AspNetCore.Identity;

namespace Error404NotLost_DAL.Entities
{
    public class Tutoring
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; } = null!;
        public string AuthorId { get; set; } = null!;
        public IdentityUser Author { get; set; } = null!;
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
