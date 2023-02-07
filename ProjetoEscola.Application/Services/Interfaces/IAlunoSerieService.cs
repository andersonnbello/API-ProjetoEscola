using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IAlunoSerieService
    {
        ResultService<AlunoSerieDTO> CreateAsync(AlunoSerieDTO studentSerieDTO);
        Task<ResultService> UpdateAsync(AlunoSerieDTO studentSerieDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<AlunoSerieDTO>>> GetAllAsync();
        Task<ResultService<AlunoSerieDTO>> GetByIdAsync(int id);
        Task<ResultService<AlunoSerieDTO>> GetByStudentIdAsync(int id);
    }
}
