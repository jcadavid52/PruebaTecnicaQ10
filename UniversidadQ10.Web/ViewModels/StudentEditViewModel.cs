using System.ComponentModel.DataAnnotations;
using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Web.ViewModels
{
    public class StudentEditViewModel
    {
        [Required]
        public int Id { get; set; } = default!;

        [Required]
        [Display(Name = "Nombre completo")]
        [StringLength(StudentPropiertiesLength.FullNameMaxLength, MinimumLength = StudentPropiertiesLength.FullNameMinLength)]
        public string FullName { get; set; } = default!;


        [Required]
        [EmailAddress]
        [StringLength(StudentPropiertiesLength.EmailMaxLength, MinimumLength = StudentPropiertiesLength.EmailMinLength)]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(StudentPropiertiesLength.DocumentMaxLength, MinimumLength = StudentPropiertiesLength.DocumentMinLength)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo se permiten números.")]
        [Display(Name = "Documento")]
        public string Document { get; set; } = default!;
    }
}
