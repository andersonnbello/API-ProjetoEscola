using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IDisciplinaRepository
    {
        Disciplina CreateAsync(Disciplina subject);
        Disciplina UpdateAsync(Disciplina subject);
        Task DeleteAsync(Disciplina subject);

        Task<Disciplina> GetById(int id);
        Task<IEnumerable<Disciplina>> GetAllAsync();
    }
}
