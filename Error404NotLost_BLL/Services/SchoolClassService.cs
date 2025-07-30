using Error404NotLost_DAL;
using Error404NotLost_DTO.Global;
using Microsoft.EntityFrameworkCore;

namespace Error404NotLost_BLL.Services
{
    public interface ISchoolClassService
    {
        Task<List<SchoolClassListingDto>> GetAllSchoolClass();
    }

    public class SchoolClassService : ISchoolClassService
    {
        private readonly Error404NotLostDbContext _context;

        public SchoolClassService(Error404NotLostDbContext context)
        {
            _context = context;
        }

        public async Task<List<SchoolClassListingDto>> GetAllSchoolClass()
        {
            return await _context.SchoolClasses
                .Select(sc => new SchoolClassListingDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    AuthorName = sc.Author.UserName ?? "Auteur inconnu",
                    CreatedAt = sc.CreatedAt,
                    UpdatedAt = sc.UpdatedAt
                })
                .ToListAsync();
        }

    }
}
