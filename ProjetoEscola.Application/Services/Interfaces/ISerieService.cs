using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ISerieService
    {
        ResultService<SerieDTO> CreateAsync(SerieDTO serieDTO);
        Task<ResultService<IEnumerable<SerieDTO>>> GetAllAsync();
        Task<ResultService<SerieDTO>> GetById(int id);
        Task<ResultService> UpdateAsync(SerieDTO serieDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
