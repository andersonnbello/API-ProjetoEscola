using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ISerieRepository
    {
        Serie CreateAsync(Serie serie);
        Serie UpdateAsync(Serie serie);
        Task DeleteAsync(Serie serie);

        Task<Serie> GetById(int id);
        Task<IEnumerable<Serie>> GetAllAsync();
    }
}
