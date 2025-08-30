using Error404NotLost_BLL.Services;
using Error404NotLost_DTO.Global;
using Microsoft.AspNetCore.Mvc;

namespace Error404NotLost_WEBASP.Controllers
{
    public class SchoolClassController : Controller
    {
        private readonly SchoolClassService _schoolClassService;

        public SchoolClassController(SchoolClassService schoolClassService)
        {
            _schoolClassService = schoolClassService;
        }

        public async Task<IActionResult> Index()
        {
            List<SchoolClassListingDto> schoolClasses = await _schoolClassService.GetAllSchoolClass();

            return View(schoolClasses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(SchoolClassCreationDto schoolClassDto)
        {
            if (!ModelState.IsValid)
            {
                return View(schoolClassDto);
            }
            var existingClass = await _schoolClassService.GetSchoolClassByName(schoolClassDto.Name);
            if (existingClass != null)
            {
                ModelState.AddModelError("Name", "Une classe avec ce nom existe déjà.");
                return View(schoolClassDto);
            }

            // L'utilisateur est forcément connecté pour créer une classe
            string authorId = User.Identity?.Name!;

            await _schoolClassService.AddSchoolClass(schoolClassDto, authorId);
            return RedirectToAction("Index");
        }
    }
}
