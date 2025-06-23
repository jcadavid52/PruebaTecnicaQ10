using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using UniversidadQ10.Domain.Dtos;

namespace UniversidadQ10.Web.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name = "Estudiante")]
        public int? SelectedStudentId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Materia")]
        public int? SelectedSubjectId { get; set; }

        public IEnumerable<SelectListItem> Students { get; set; } = new List<SelectListItem>();

        public IEnumerable<SelectListItem> Subjects { get; set; } = new List<SelectListItem>();

        public IEnumerable<RegistrationDto> Registrations { get; set; } = new List<RegistrationDto>();

    }
}
