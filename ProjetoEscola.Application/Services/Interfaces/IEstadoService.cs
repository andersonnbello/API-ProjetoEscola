using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IEstadoService
    {
        ResultService<EstadoDTO> CreateAsync(EstadoDTO stateDTO);
        Task<ResultService> UpdateAsync(EstadoDTO stateDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<EstadoDTO>>> GetAllAsync();
        Task<ResultService<EstadoDTO>> GetById(int id);
        Task<ResultService<EstadoDTO>> GetByNameAsync(string stateName);

    }
}
