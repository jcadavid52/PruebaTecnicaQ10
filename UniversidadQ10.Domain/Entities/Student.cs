using UniversidadQ10.Domain.Common;

namespace UniversidadQ10.Domain.Entities
{
    public class Student:DomainEntity
    {
        private string _fullName = string.Empty;
        private string _document = string.Empty;
        private string _email = string.Empty;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                if (value.Length < StudentPropiertiesLength.FullNameMinLength || value.Length > StudentPropiertiesLength.FullNameMaxLength)
                    throw new ArgumentException($"El nombre debe tener entre {StudentPropiertiesLength.FullNameMinLength} y {StudentPropiertiesLength.FullNameMaxLength} caracteres.");
                _fullName = value;
            }
        }
        public string Document
        {
            get => _document;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El documento no puede estar vacío.");
                if (value.Length < StudentPropiertiesLength.DocumentMinLength || value.Length > StudentPropiertiesLength.DocumentMaxLength)
                    throw new ArgumentException($"El documento debe tener entre {StudentPropiertiesLength.DocumentMinLength} y {StudentPropiertiesLength.DocumentMaxLength} caracteres.");
                _document = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El email no puede estar vacío.");
                if (value.Length < StudentPropiertiesLength.EmailMinLength || value.Length > StudentPropiertiesLength.EmailMaxLength)
                    throw new ArgumentException($"El email debe tener entre {StudentPropiertiesLength.EmailMinLength} y {StudentPropiertiesLength.EmailMaxLength} caracteres.");
                _email = value;
            }
        }
        public ICollection<Registration> Registration { get; set; } = default!;
    }
}
