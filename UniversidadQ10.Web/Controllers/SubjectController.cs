using Microsoft.AspNetCore.Mvc;
using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Web.ViewModels;

namespace UniversidadQ10.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var subjectsList = await _subjectService.GetAllSubjectsAsync();
            return View(subjectsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var subjectCreateDto = new SubjectCreateDto(viewModel.Name,viewModel.Credit ?? 0);

            await _subjectService.CreateSubjectAsync(subjectCreateDto);

            TempData["ToastrMessage"] = "Registro creado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _subjectService.GetSubjectById(id);
            var subjectEditViewModel = new SubjectEditViewModel
            {
                Name = subject.Name,
                Credit = subject.Credit,
            };
            return View(subjectEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SubjectEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var subjectEditDto = new SubjectEditDto(viewModel.Name,viewModel.Credit ?? 0);

            await _subjectService.UpdateSubjectAsync(id, subjectEditDto);

            TempData["ToastrMessage"] = "Registro editado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);

            TempData["ToastrMessage"] = "Registro eliminado exitosamente";
            TempData["ToastrType"] = "success";
            TempData.Save();

            return RedirectToAction("Index");
        }
    }
}
