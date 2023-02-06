using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStateService
    {
        ResultService<StateDTO> CreateAsync(StateDTO stateDTO);
        Task<ResultService> UpdateAsync(StateDTO stateDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<StateDTO>>> GetAllAsync();
        Task<ResultService<StateDTO>> GetById(int id);
        Task<ResultService<StateDTO>> GetByNameAsync(string stateName);

    }
}
