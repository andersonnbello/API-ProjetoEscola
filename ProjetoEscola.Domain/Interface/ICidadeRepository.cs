using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ICidadeRepository
    {
        Cidade CreateAsync(Cidade city);
        Cidade UpdateAsync(Cidade city);
        Task DeleteAsync(Cidade city);

        Task<Cidade> GetById(int id);
        Task<Cidade> GetByNameAsync(string cityName);
        Task<IEnumerable<Cidade>> GetAllAsync();
    }
}
