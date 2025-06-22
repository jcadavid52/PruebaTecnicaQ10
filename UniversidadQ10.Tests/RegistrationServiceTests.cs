using NSubstitute;
using UniversidadQ10.Aplication.Registration;
using UniversidadQ10.Domain.Dtos;
using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Tests.DataBuilder;

namespace UniversidadQ10.Tests
{
    public class RegistrationServiceTests
    {
        private readonly ISubjectRepository _subjectRepository = Substitute.For<ISubjectRepository>();
        private readonly IRegistrationRepository _registrationRepository = Substitute.For<IRegistrationRepository>();
        private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
        private readonly RegistrationService _service;

        public RegistrationServiceTests()
        {
            _service = new RegistrationService(_subjectRepository, _unitOfWork, _registrationRepository);
        }

        [Fact]
        public async Task CreateRegistrationAsync_SubjectCreditLessThanOrEqualTo3_CreateSuccess()
        {
            //Arrange
            var registrationCreateDto = new RegistrationCreateDto(1, 2);
            
            var subject = new Subject
            {
                Id = 2,
                Credit = 3
            };

            _subjectRepository.GetByIdAsync(registrationCreateDto.SubjectId)!.Returns(Task.FromResult(subject));

            // Act
            await _service.CreateRegistrationAsync(registrationCreateDto);

            // Assert
            await _registrationRepository.Received(1).CreateAsync(Arg.Is<Registration>(r =>
                r.StudentId == registrationCreateDto.StudentId &&
                r.SubjectId == registrationCreateDto.SubjectId
            ));

            await _unitOfWork.Received(1).SaveChangesAsync();

            await _registrationRepository.DidNotReceive()
                .CountAsync(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public async Task GetAllRegistrationsAsync_WhenCalled_ReturnsMappedRegistration()
        {
            var registrationDataBuilder = new RegistrationDataBuilder();
            var studentDataBuilder = new StudentDataBuilder();
            var subjectDataBuilder = new SubjectDataBuilder();

            var subject1 = subjectDataBuilder
                .WithId(10)
                .WithName("MateriaTest1@test.com")
                .WithCredit(3)
                .Build();

            var subject2 = subjectDataBuilder
                .WithId(20)
                .WithName("MateriaTest2@test.com")
                .WithCredit(10)
                .Build();

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


            var registrationList = new List<Registration>
            {
                registrationDataBuilder
                .WithId(1)
                .WithStudentId(student1.Id)
                .WithSubjectId(subject1.Id)
                .WithStudent(student1)
                .WithSubject(subject1)
                .Build(),
                registrationDataBuilder
                .WithId(2)
                .WithStudentId(student2.Id)
                .WithSubjectId(subject2.Id)
                .WithStudent(student2)
                .WithSubject(subject2)
                .Build(),

            };

            _registrationRepository.GetAllAsync().Returns(registrationList);

            //Act
            var registrationsResult = await _service.GetAllRegistrationsAsync();

            //Assert
            await _registrationRepository.Received(1).GetAllAsync();
            Assert.Equal(registrationList.Count, registrationsResult.Count());
        }

    }
}
