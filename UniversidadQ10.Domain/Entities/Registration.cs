using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Domain.Entities
{
    public class Registration:DomainEntity
    {
        private DateTime _registrationDate = DateTime.Now;
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime RegistrationDate { get => _registrationDate;}
        public Student Student { get; set; } = default!;
        public Subject Subject { get; set; } = default!;
    }
}
