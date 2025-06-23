using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Web.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (TempData["CoreBusinessError"] is string MessageError)
            {
                TempData["ToastrMessage"] = MessageError;
                TempData["ToastrType"] = "warning";
            }

            var registrationViewModel = await GetSelectList();

            return View(registrationViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationViewModel viewModel)
        {
            var registrationViewModel = new RegistrationViewModel();

            if (!ModelState.IsValid)
            {
                registrationViewModel = await GetSelectList();
                return View("Index", registrationViewModel);
            }

            var registrationCreateDto = new RegistrationCreateDto(viewModel.SelectedStudentId ?? 0,viewModel.SelectedSubjectId ?? 0);

            await _registrationService.CreateRegistrationAsync(registrationCreateDto);

            registrationViewModel = await GetSelectList();

            TempData["ToastrMessage"] = "Registro creado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

            return RedirectToAction("Index");
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
