using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IProfessorService
    {
        ResultService<ProfessorDTO> CreateAsync(ProfessorDTO teachersDTO);
        Task<ResultService> UpdateAsync(ProfessorDTO teachersDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<List<ProfessorDTO>>> GetAllAsync();
        Task<ResultService<ProfessorDTO>> GetByIdAsync(int id);
    }
}
