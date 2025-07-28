using Error404NotLost_DAL;

namespace Error404NotLost_BLL.Services
{
    public interface ISchoolSubjectService
    {
        // Define methods for the SchoolSubjectService here
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

        // Implement methods for manipulating school subjects here
    }
}
