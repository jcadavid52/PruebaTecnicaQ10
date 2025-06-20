using Microsoft.AspNetCore.Mvc;

namespace UniversidadQ10.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
