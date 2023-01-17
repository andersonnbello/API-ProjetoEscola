using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentsSubjectsService
    {
        ResultService<StudentsSubjectsDTO> CreateAsync(StudentsSubjectsDTO studentsSubjectsDTO);
        Task<ResultService> UpdateAsync(StudentsSubjectsDTO studentsSubjectsDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<StudentsSubjectsDTO>>> GetAllAsync();
        Task<ResultService<IEnumerable<StudentsSubjectsDTO>>> GetAllAsync(int id);
        Task<ResultService<StudentsSubjectsDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentsSubjectsDTO>> GetByStudentIdAsync(int id);
        Task<ResultService<StudentsSubjectsDTO>> GetBySubjectIdAsync(int id);
    }
}
