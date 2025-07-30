using System.ComponentModel.DataAnnotations;

namespace Error404NotLost_DTO.Global
{
    /// <summary>
    /// Permet de lister les classes
    /// </summary>
    public class SchoolClassListingDto
    {
        public int Id { get; set; }
        [Display(Name = "Promotion")]
        public string Name { get; set; } = null!;
        [Display(Name = "Auteur")]
        public string AuthorName { get; set; } = null!;
        [Display(Name = "Date de création")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Date de modification")]
        public DateTime UpdatedAt { get; set; }
    }
}
