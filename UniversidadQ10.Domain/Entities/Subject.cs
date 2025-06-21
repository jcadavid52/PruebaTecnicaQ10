using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Domain.Entities
{
    public class Subject:DomainEntity
    {
        private string _name = string.Empty;
        private int _credit;
        private readonly Guid _code = Guid.NewGuid();
        public string Name
        { 
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("El nombre no puede ser nulo ni vacío.");

                if (value.Length < SubjectPropiertiesLength.NameMinLength || value.Length > SubjectPropiertiesLength.NameMaxLength)
                    throw new ArgumentException($"El nombre debe tener entre {SubjectPropiertiesLength.NameMinLength} y {SubjectPropiertiesLength.NameMaxLength} caracteres.");

                _name = value;
            } 
        }

        public Guid Code { get => _code; }

        public int Credit
        {
            get => _credit;
            set
            {
                if (value < SubjectPropiertiesLength.CreditMin || value > SubjectPropiertiesLength.CreditMax)
                    throw new ArgumentException($"La cantidad de créditos deben estar dentro de {SubjectPropiertiesLength.CreditMin} y {SubjectPropiertiesLength.CreditMax}");
            }
        }

        public ICollection<Registration> Registration { get; set; } = default!;
    }
}
