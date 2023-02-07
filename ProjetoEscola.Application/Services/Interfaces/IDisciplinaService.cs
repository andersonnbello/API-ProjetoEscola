using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IDisciplinaService
    {
        ResultService<DisciplinaDTO> CreateAsync(DisciplinaDTO subjectsDTO);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService> UpdateAsync(DisciplinaDTO subjectsDTO);

        Task<ResultService<IEnumerable<DisciplinaDTO>>> GetAllAsync();
        Task<ResultService<DisciplinaDTO>> GetByIdAsync(int id);
    }
}
