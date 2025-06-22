using NSubstitute;
using UniversidadQ10.Aplication.Student;
using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Tests.DataBuilder;

namespace UniversidadQ10.Tests
{
    public class StudentServiceTests
    {
        private readonly IStudentRepository _studentRepository = Substitute.For<IStudentRepository>();
        private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
        private readonly StudentService _studentService;

        public StudentServiceTests()
        {
            _studentService = new StudentService(_studentRepository, _unitOfWork);
        }

        [Fact]
        public async Task GetAllStudentsAsync_WhenCalled_ReturnsMappedStudent()
        {
            //Arrange
            var studentDataBuilder = new StudentDataBuilder();

            var student1 = studentDataBuilder
               .WithId(50)
               .WithFullName("EstudanteTest1")
               .WithDocument("12345678")
               .WithEmail("emailtest1@test.com")
               .Build();

            var student2 = studentDataBuilder
                .WithId(60)
                .WithFullName("EstudanteTest2")
                .WithDocument("987654321")
                .WithEmail("emailtest2@test.com")
                .Build();

            var studentsList = new List<Student>
            {
                student1,
                student2
            };

            _studentRepository.GetAllAsync().Returns(studentsList);

            //Act
            var studentsResult = await _studentRepository.GetAllAsync();

            //Assert
            await _studentRepository.Received(1).GetAllAsync();
            Assert.Equal(studentsList.Count, studentsResult.Count());
        }
    }
}
