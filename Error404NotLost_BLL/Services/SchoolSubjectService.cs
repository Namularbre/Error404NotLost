using Error404NotLost_DAL;
using Error404NotLost_DTO.Global;
using Microsoft.EntityFrameworkCore;

namespace Error404NotLost_BLL.Services
{
    public interface ISchoolSubjectService
    {
        Task<List<SchoolSubjectListingDto>> ListSchoolSubject();
    }

    /// <summary>
    /// Manages school subjects in the application.
    /// </summary>
    public class SchoolSubjectService : ISchoolSubjectService
    {
        private readonly Error404NotLostDbContext _context;

        public SchoolSubjectService(Error404NotLostDbContext context)
        {
            _context = context;
        }

        public async Task<List<SchoolSubjectListingDto>> ListSchoolSubject()
        {
            return await _context.SchoolSubjects
                .Select(s => new SchoolSubjectListingDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToListAsync();
        }
    }
}
