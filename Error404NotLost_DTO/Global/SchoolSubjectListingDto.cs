using System.ComponentModel.DataAnnotations;

namespace Error404NotLost_DTO.Global
{
    public class SchoolSubjectListingDto
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string Name { get; set; } = null!;
    }
}
