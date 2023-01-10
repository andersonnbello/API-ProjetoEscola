using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentsSubjectsService
    {
        Task<ResultService<IEnumerable<StudentsSubjectsDTO>>> GetAllAsync();
        Task<ResultService<IEnumerable<StudentsSubjectsDTO>>> GetAllAsync(int id);
        ResultService<StudentsSubjectsDTO> CreateAsync(StudentsSubjectsDTO studentsSubjectsDTO);
        Task<ResultService> UpdateAsync(StudentsSubjectsDTO studentsSubjectsDTO);
        Task<ResultService<StudentsSubjectsDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentsSubjectsDTO>> GetByStudentIdAsync(int id);
        Task<ResultService> DeleteAsync(int id);
    }
}
