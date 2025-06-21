using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace UniversidadQ10.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string? message = null)
        {
            ViewBag.Message = message ?? TempData["ErrorMessage"]?.ToString() ?? "Ha ocurrido un error inesperado.";

            return View();
        }
    }
}
