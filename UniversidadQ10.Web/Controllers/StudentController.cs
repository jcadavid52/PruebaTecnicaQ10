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
        [HttpGet]
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

            var studentCreateDto = new StudentCreateDto(viewModel.FullName, viewModel.Email, viewModel.Document);

            await _studentService.CreateStudentAsync(studentCreateDto);

            TempData["ToastrMessage"] = "Registro creado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

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

            var studentEditDto = new StudentEditDto(viewModel.Id, viewModel.FullName, viewModel.Email, viewModel.Document);

            await _studentService.UpdateStudentAsync(id, studentEditDto);

            TempData["ToastrMessage"] = "Registro editado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.DeleteStudentAsync(id);

            TempData["ToastrMessage"] = "Registro eliminado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

            return  RedirectToAction("Index");
        }
    }
}
