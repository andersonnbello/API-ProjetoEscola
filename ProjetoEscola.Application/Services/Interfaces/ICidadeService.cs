using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ICidadeService
    {
        ResultService<CidadeDTO> CreateAsync(CidadeDTO cityDTO);
        Task<ResultService> UpdateAsync(CidadeDTO cityDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<CidadeDTO>>> GetAllAsync();
        Task<ResultService<CidadeDTO>> GetById(int id);
        Task<ResultService<CidadeDTO>> GetByNameAsync(string cityName);
    }
}
