using Error404NotLost_BLL.Services;
using Error404NotLost_DTO.Global;
using Microsoft.AspNetCore.Mvc;

namespace Error404NotLost_WEBASP.Controllers
{
    public class SchoolClassController : Controller
    {
        private readonly ISchoolClassService _schoolClassService;

        public SchoolClassController(ISchoolClassService schoolClassService)
        {
            _schoolClassService = schoolClassService;
        }

        public async Task<IActionResult> Index()
        {
            List<SchoolClassListingDto> schoolClasses = await _schoolClassService.GetAllSchoolClass();

            return View(schoolClasses);
        }
    }
}
