using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IAlunoDisciplinaService
    {
        ResultService<AlunoDisciplinaDTO> CreateAsync(AlunoDisciplinaDTO studentsSubjectsDTO);
        Task<ResultService> UpdateAsync(AlunoDisciplinaDTO studentsSubjectsDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<AlunoDisciplinaDTO>>> GetAllAsync();
        Task<ResultService<IEnumerable<AlunoDisciplinaDTO>>> GetAllAsync(int id);
        Task<ResultService<AlunoDisciplinaDTO>> GetByIdAsync(int id);
        Task<ResultService<AlunoDisciplinaDTO>> GetByStudentIdAsync(int id);
        Task<ResultService<AlunoDisciplinaDTO>> GetBySubjectIdAsync(int id);
    }
}
