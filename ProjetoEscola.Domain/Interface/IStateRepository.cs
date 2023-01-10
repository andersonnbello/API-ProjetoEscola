using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IStateRepository
    {
        State CreateAsync(State state);
        State UpdateAsync(State state);
        Task<State> GetById(int id);
        Task<IEnumerable<State>> GetAllAsync();
        Task DeleteAsync(State state);
    }
}
