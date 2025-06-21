using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Web.ViewModels;

namespace UniversidadQ10.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IRegistrationService _registrationService;
        public RegistrationController(IStudentService studentService, ISubjectService subjectService, IRegistrationService registrationService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _registrationService = registrationService;
        }
        public async Task<IActionResult> Index()
        {
            var registrationViewModel = await GetSelectList();

            return View(registrationViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationViewModel viewModel)
        {
            var registrationCreateDto = new RegistrationCreateDto(viewModel.SelectedStudentId,viewModel.SelectedSubjecttId);

            await _registrationService.CreateRegistrationAsync(registrationCreateDto);

            var registrationViewModel = await GetSelectList();

            return View("Index", registrationViewModel);
        }

        private async Task<RegistrationViewModel> GetSelectList()
        {
            var studentList = await _studentService.GetAllStudentsAsync();
            var subjectList = await _subjectService.GetAllSubjectsAsync();
            var registrationList = await _registrationService.GetAllRegistrationsAsync();

            var studentSelectList = studentList.Select(student => new SelectListItem
            {
                Value = student.Id.ToString(),
                Text = student.FullName,
            });

            var subjectSelectList = subjectList.Select(subject => new SelectListItem
            {
                Value = subject.Id.ToString(),
                Text = subject.Name
            });

            var registrationViewModel = new RegistrationViewModel
            {
                Students = studentSelectList,
                Subjects = subjectSelectList,
                Registrations = registrationList
            };

            return registrationViewModel;
        }
    }
}
