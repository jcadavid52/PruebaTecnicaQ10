using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Web.ViewModels;

namespace UniversidadQ10.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IActionResult> Index()
        {
            var studentsList = await _studentService.GetAllStudentsAsync();
            return View(studentsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var studentDto = new StudentCreateDto(viewModel.FullName, viewModel.Email, viewModel.Document);

            await _studentService.CreateStudentAsync(studentDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentById(id);
            var studentEditViewModel = new StudentEditViewModel
            {
                FullName = student.FullName,
                Email = student.Email,
                Document = student.Document,
            };
            return View(studentEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudentEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var studentDto = new StudentDto(viewModel.Id, viewModel.FullName, viewModel.Email, viewModel.Document);

            await _studentService.UpdateStudentAsync(id, studentDto);
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteStudentAsync(id);

            return  RedirectToAction("Index");
        }
    }
}
