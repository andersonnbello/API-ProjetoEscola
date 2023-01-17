using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStateService
    {
        ResultService<StateDTO> CreateAsync(StateDTO stateDTO);
        Task<ResultService> UpdateAsync(StateDTO stateDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<StateDTO>>> GetAllAsync();
        Task<ResultService<StateDTO>> GetById(int id); 
    }
}
