using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ICityRepository
    {
        City CreateAsync(City city);
        City UpdateAsync(City city);
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetAllAsync();
        Task DeleteAsync(City city);
    }
}
