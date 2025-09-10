using Error404NotLost_BLL.Services;
using Error404NotLost_DAL.Roles;
using Error404NotLost_DTO.Global;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Error404NotLost_WEBASP.Controllers
{
    public class SchoolClassController : BaseController
    {
        private readonly ILogger<SchoolClassController> _logger;
        private readonly SchoolClassService _schoolClassService;

        public SchoolClassController(ILogger<SchoolClassController> logger, SchoolClassService schoolClassService)
        {
            _logger = logger;
            _schoolClassService = schoolClassService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SchoolClassListingDto> schoolClasses = await _schoolClassService.GetAllSchoolClass();

            return View(schoolClasses);
        }

        public async Task<IActionResult> Dashboard()
        {
            List<SchoolClassListingDto> schoolClasses = await _schoolClassService.GetAllSchoolClass();
            return View(schoolClasses);
        }

        [HttpGet]
        [Authorize(Roles = nameof(ERoles.Admin) + "," + nameof(ERoles.Moderator))]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = nameof(ERoles.Admin) + "," + nameof(ERoles.Moderator))]
        public async Task<IActionResult> Create(SchoolClassCreationDto schoolClassDto)
        {
            if (!ModelState.IsValid)
                return View(schoolClassDto);
            
            var existingClass = await _schoolClassService.GetSchoolClassByName(schoolClassDto.Name);
            if (existingClass != null)
            {
                ModelState.AddModelError("Name", "Une classe avec ce nom existe déjà.");
                return View(schoolClassDto);
            }

            // You must be logged in to use this action
            string authorId = GetCurrentUserId()!;

            await _schoolClassService.AddSchoolClass(schoolClassDto, authorId);
            return RedirectToAction(nameof(Dashboard));
        }

        [HttpGet]
        [Authorize(Roles = nameof(ERoles.Admin) + "," + nameof(ERoles.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            var schoolClass = await _schoolClassService.GetSchoolClassUpdateDtoById(id);

            if (schoolClass == null)
                return NotFound();

            return View(schoolClass);
        }

        [HttpPost]
        [Authorize(Roles = nameof(ERoles.Admin) + "," + nameof(ERoles.Moderator))]
        public async Task<IActionResult> Update(SchoolClassUpdateDto schoolClassDto)
        {
            if (!ModelState.IsValid)
                return View(schoolClassDto);
            var existingClass = await _schoolClassService.GetSchoolClassByName(schoolClassDto.Name);
            if (existingClass != null && existingClass.Id != schoolClassDto.Id)
            {
                ModelState.AddModelError("Name", "Une classe avec ce nom existe déjà.");
                return View(schoolClassDto);
            }
            await _schoolClassService.UpdateSchoolClass(schoolClassDto);
            return RedirectToAction(nameof(Dashboard));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var schoolClass = await _schoolClassService.GetSchoolClassById(id);
            if (schoolClass == null)
                return NotFound();
            await _schoolClassService.DeleteSchoolClass(schoolClass);
            return RedirectToAction(nameof(Dashboard));
        }
    }
}
