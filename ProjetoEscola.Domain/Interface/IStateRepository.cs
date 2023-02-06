using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IStateRepository
    {
        State CreateAsync(State state);
        State UpdateAsync(State state);
        Task DeleteAsync(State state);

        Task<State> GetById(int id);
        Task<State> GetByNameAsync(string stateName);
        Task<IEnumerable<State>> GetAllAsync();
    }
}
