using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ICityRepository
    {
        City CreateAsync(City city);
        City UpdateAsync(City city);
        Task DeleteAsync(City city);

        Task<City> GetById(int id);
        Task<City> GetByNameAsync(string cityName);
        Task<IEnumerable<City>> GetAllAsync();
    }
}
