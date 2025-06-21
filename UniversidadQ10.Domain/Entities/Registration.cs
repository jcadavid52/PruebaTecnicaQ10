using UniversidadQ10.Domain.Common;
using UniversidadQ10.Domain.Exceptions;

namespace UniversidadQ10.Domain.Entities
{
    public class Registration:DomainEntity
    {
        private DateTime _registrationDate = DateTime.Now;
        private const int _quantityPermittedSubjects = 3;
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime RegistrationDate { get => _registrationDate;}
        public Student Student { get; set; } = default!;
        public Subject Subject { get; set; } = default!;

        public void ValidateCreditsSubjectStudent(int quantitySubjects)
        {
            if (quantitySubjects >= _quantityPermittedSubjects)
                throw new CoreBusinessException($"El estudiante ha superado el tope de materias con créditos mayores a {_quantityPermittedSubjects}");
        }
    }
}
