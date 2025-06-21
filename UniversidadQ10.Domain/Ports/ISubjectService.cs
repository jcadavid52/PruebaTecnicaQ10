using UniversidadQ10.Domain.Dtos;

namespace UniversidadQ10.Domain.Ports
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectById(int id);
        Task CreateSubjectAsync(SubjectCreateDto subjectCreateDto);
        Task UpdateSubjectAsync(int id, SubjectEditDto subjectEditDto);
        Task DeleteSubjectAsync(int id);
    }
}
