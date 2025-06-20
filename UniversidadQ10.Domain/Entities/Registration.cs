namespace UniversidadQ10.Domain.Entities
{
    public class Registration:DomainEntity
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Student Student { get; set; } = default!;
        public Subject Subject { get; set; } = default!;
    }
}
