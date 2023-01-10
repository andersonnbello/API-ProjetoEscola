using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ICountryRepository
    {
        Country CreateAsync(Country country);
        Country UpdateAsync(Country country);
        Task<Country> GetById(int id);
        Task<IEnumerable<Country>> GetAllAsync();
        Task DeleteAsync(Country country);
    }
}
