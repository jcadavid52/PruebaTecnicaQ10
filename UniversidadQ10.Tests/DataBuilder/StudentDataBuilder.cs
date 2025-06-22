using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Tests.DataBuilder
{
    public class StudentDataBuilder
    {
        private int _id = 50;
        private string _fullName = string.Empty;
        private string _document = string.Empty;
        private string _email = string.Empty;

        public StudentDataBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public StudentDataBuilder WithFullName(string fullName)
        {
            _fullName = fullName;
            return this;
        }

        public StudentDataBuilder WithDocument(string document)
        {
            _document = document;
            return this;
        }

        public StudentDataBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public Student Build()
        {
            return new Student()
            {
                Id = _id,
                FullName = _fullName,
                Document = _document,
                Email = _email
            };
        }
    }
}
