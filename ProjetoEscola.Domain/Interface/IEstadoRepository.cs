using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IEstadoRepository
    {
        Estado CreateAsync(Estado state);
        Estado UpdateAsync(Estado state);
        Task DeleteAsync(Estado state);

        Task<Estado> GetById(int id);
        Task<Estado> GetByNameAsync(string stateName);
        Task<IEnumerable<Estado>> GetAllAsync();
    }
}
