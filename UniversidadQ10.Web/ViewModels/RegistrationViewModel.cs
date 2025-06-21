using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using UniversidadQ10.Domain.Dtos;

namespace UniversidadQ10.Web.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public int SelectedStudentId { get; set; }

        [Required]
        public int SelectedSubjecttId { get; set; }

        public IEnumerable<SelectListItem> Students { get; set; } = default!;

        public IEnumerable<SelectListItem> Subjects { get; set; } = default!;
    }
}
