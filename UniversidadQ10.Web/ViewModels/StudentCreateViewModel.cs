using System.ComponentModel.DataAnnotations;
using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre completo")]
        [StringLength(StudentPropiertiesLength.FullNameMaxLength, MinimumLength = StudentPropiertiesLength.FullNameMinLength, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string FullName { get; set; } = default!;

        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress]
        [StringLength(StudentPropiertiesLength.EmailMaxLength, MinimumLength = StudentPropiertiesLength.EmailMinLength, ErrorMessage = "El correo debe tener entre 5 y 100 caracteres")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(StudentPropiertiesLength.DocumentMaxLength, MinimumLength = StudentPropiertiesLength.DocumentMinLength,ErrorMessage ="El número de documento debe tener entre 3 y 20 caracteres")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se permiten números.")]
        [Display(Name = "Documento")]
        public string Document { get; set; } = default!;
    }
}
