using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ICountryService
    {
        ResultService<CountryDTO> CreateAsync(CountryDTO countryDTO);
        Task<ResultService> UpdateAsync(CountryDTO countryDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<CountryDTO>>> GetAllAsync();
        Task<ResultService<CountryDTO>> GetById(int id);
    }
}
