using NSubstitute;
using UniversidadQ10.Aplication.Subject;
using UniversidadQ10.Domain.Entities;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Tests.DataBuilder;

namespace UniversidadQ10.Tests
{
    public class SubjectServiceTests
    {
        private readonly ISubjectRepository _subjectRepository = Substitute.For<ISubjectRepository>();
        private readonly IUnitOfWork _unitOfWork = Substitute.For<IUnitOfWork>();
        private readonly SubjectService _subjectService;

        public SubjectServiceTests()
        {
            _subjectService = new SubjectService(_subjectRepository, _unitOfWork);
        }

        [Fact]
        public async Task GetAllSubjectsAsync_WhenCalled_ReturnsMappedStudent()
        {
            //Arrange
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

            var subjectsList = new List<Subject>
            {
                subject1,
                subject2
            };

            _subjectRepository.GetAllAsync().Returns(subjectsList);

            //Act
            var subjectsResult = await _subjectRepository.GetAllAsync();

            //Assert
            await _subjectRepository.Received(1).GetAllAsync();
            Assert.Equal(subjectsList.Count, subjectsResult.Count());

        }
    }
}
