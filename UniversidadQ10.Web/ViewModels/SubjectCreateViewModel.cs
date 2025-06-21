using System.ComponentModel.DataAnnotations;
using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Web.ViewModels
{
    public class SubjectCreateViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(SubjectPropiertiesLength.NameMaxLength, MinimumLength = SubjectPropiertiesLength.NameMinLength)]
        public string Name { get; set; } = default!;
        [Required]
        [Display(Name = "Créditos")]
        [Range(SubjectPropiertiesLength.CreditMin, SubjectPropiertiesLength.CreditMax, ErrorMessage = $"El valor debe estar entre 1 y 25.")]
        public int Credit { get; set; }
    }
}
