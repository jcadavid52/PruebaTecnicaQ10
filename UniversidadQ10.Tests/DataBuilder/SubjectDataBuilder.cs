using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Tests.DataBuilder
{
    public class SubjectDataBuilder
    {
        private string _name = "materiaTest";
        private int _id = 50;
        private int _credit = 3;

        public SubjectDataBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public SubjectDataBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public SubjectDataBuilder WithCredit(int credit)
        {
            _credit = credit;
            return this;
        }

        public Subject Build()
        {
            return new Subject()
            {
                Id = _id,
                Name = _name,
                Credit = _credit
            };
        }
    }
}
