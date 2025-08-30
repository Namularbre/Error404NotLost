using Error404NotLost_DAL;
using Error404NotLost_DAL.Entities;
using Error404NotLost_DTO.Global;
using Microsoft.EntityFrameworkCore;

namespace Error404NotLost_BLL.Services
{
    public class SchoolClassService
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

        public async Task<SchoolClass?> GetSchoolClassById(int id)
        {
            return await _context.SchoolClasses
                .Include(sc => sc.Subjects)
                .FirstOrDefaultAsync(sc => sc.Id == id);
        }

        public async Task<SchoolClass?> GetSchoolClassByName(string name)
        {
            return await _context.SchoolClasses
                .Include(sc => sc.Subjects)
                .FirstOrDefaultAsync(sc => sc.Name == name);
        }

        /// <summary>
        /// Add a new school class to the database. The name must be unique.
        /// </summary>
        /// <param name="schoolClass"></param>
        /// <exception cref="InvalidOperationException">if name is already taken</exception>
        /// <returns></returns>
        public async Task AddSchoolClass(SchoolClassCreationDto dto, string authorId)
        {
            if (await _context.SchoolClasses.AnyAsync(sc => sc.Name == dto.Name))
                throw new InvalidOperationException("A school class with the same name already exists.");
            
            var schoolClass = new SchoolClass
            {
                Name = dto.Name,
                AuthorId = authorId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.SchoolClasses.Add(schoolClass);
            await _context.SaveChangesAsync();
        }
    }
}
