using System.ComponentModel.DataAnnotations;
using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Web.ViewModels
{
    public class SubjectCreateViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre")]
        [StringLength(SubjectPropiertiesLength.NameMaxLength, MinimumLength = SubjectPropiertiesLength.NameMinLength,ErrorMessage ="El nombre de tener entre 3 y 80 caracteres")]
        public string Name { get; set; } = default!;
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Créditos")]
        [Range(SubjectPropiertiesLength.CreditMin, SubjectPropiertiesLength.CreditMax, ErrorMessage = $"El valor debe estar entre 1 y 25.")]
        public int? Credit { get; set; }
    }
}
