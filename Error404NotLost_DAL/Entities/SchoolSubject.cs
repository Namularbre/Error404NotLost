using Microsoft.AspNetCore.Identity;

namespace Error404NotLost_DAL.Entities
{
    public class SchoolSubject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; } = null!;
        public List<Tutoring> Tutorings { get; set; } = new List<Tutoring>();
        public string AuthorId { get; set; } = null!;
        public IdentityUser Author { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
