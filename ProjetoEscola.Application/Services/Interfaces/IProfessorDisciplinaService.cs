using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IProfessorDisciplinaService
    {
        Task<ResultService<IEnumerable<ProfessorDisciplinaDTO>>> GetAllAsync();
        ResultService<ProfessorDisciplinaDTO> CreateAsync(ProfessorDisciplinaDTO teachersSubjectsDTO);
        Task<ResultService> UpdateAsync(ProfessorDisciplinaDTO teachersSubjectsDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<ProfessorDisciplinaDTO>> GetByIdAsync(int id);
        Task<ResultService<ProfessorDisciplinaDTO>> GetBySubjectIdAsync(int id);
        Task<ResultService<ProfessorDisciplinaDTO>> GetByTeacherIdAsync(int id);
    }
}
