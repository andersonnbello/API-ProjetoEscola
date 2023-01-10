using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ITeacherSubjectService
    {
        Task<ResultService<IEnumerable<TeachersSubjectsDTO>>> GetAllAsync();
        ResultService<TeachersSubjectsDTO> CreateAsync(TeachersSubjectsDTO teachersSubjectsDTO);
        Task<ResultService> UpdateAsync(TeachersSubjectsDTO teachersSubjectsDTO);
        Task<ResultService<TeachersSubjectsDTO>> GetByIdAsync(int id);
        Task<ResultService> DeleteAsync(int id);
    }
}
