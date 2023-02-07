using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<ResultService<IEnumerable<AlunoDTO>>> GetAllAsync();
        Task<ResultService<AlunoDTO>> CreateAsync(AlunoDTO studentsDTO);
        Task<ResultService> UpdateAsync(AlunoDTO studentsDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<AlunoDTO>> GetByIdAsync(int id);
        Task<ResultService<AlunoDTO>> GetByCPFAsync(string cpf);
        Task<ResultService<AlunoDTO>> GetByRGAsync(string rg);
    }
}
