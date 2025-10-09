using System.ComponentModel.DataAnnotations;

namespace Error404NotLost_DTO.Global
{

    public class SchoolClassCreationDto
    {
        [Required(ErrorMessage = "School class name is required")]
        [MaxLength(254, ErrorMessage = "School class name must be shorter than 254 characters")]
        [MinLength(2, ErrorMessage = "School class name must be longuer than 2 characters")]
        public string Name { get; set; } = null!;
    }
}
