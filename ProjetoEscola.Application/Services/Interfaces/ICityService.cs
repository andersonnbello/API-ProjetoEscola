using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ICityService
    {
        ResultService<CityDTO> CreateAsync(CityDTO cityDTO);
        Task<ResultService<IEnumerable<CityDTO>>> GetAllAsync();
        Task<ResultService<CityDTO>> GetById(int id);
        Task<ResultService> UpdateAsync(CityDTO cityDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
