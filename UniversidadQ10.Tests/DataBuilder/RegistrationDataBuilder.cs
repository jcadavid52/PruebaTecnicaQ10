using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Tests.DataBuilder
{
    public class RegistrationDataBuilder
    {
        private int _id = 1;
        private int _studentId = 10;
        private int _subjectId = 20;
        private StudentDataBuilder _studentDataBuilder = new();
        private SubjectDataBuilder _subjectDataBuilder = new();

        public RegistrationDataBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public RegistrationDataBuilder WithStudentId(int studentId)
        {
            _studentId = studentId;
            return this;
        }

        public RegistrationDataBuilder WithSubjectId(int subjectId)
        {
            _subjectId = subjectId;
            return this;
        }

        public RegistrationDataBuilder WithStudent(Student student)
        {
            _studentDataBuilder
                .WithId(student.Id)
                .WithFullName(student.FullName)
                .WithDocument(student.Document)
                .WithEmail(student.Email)
                .Build();
            return this;
        }

        public RegistrationDataBuilder WithSubject(Subject subject)
        {
            _subjectDataBuilder
                .WithId(subject.Id)
                .WithName(subject.Name)
                .WithCredit(subject.Credit)
                .Build();
            return this;
        }

        public Registration Build()
        {
            return new Registration
            {
                Id = _id,
                StudentId = _studentId,
                SubjectId = _subjectId,
                Student = _studentDataBuilder.Build(),
                Subject = _subjectDataBuilder.Build()
            };
        }
    }
}
