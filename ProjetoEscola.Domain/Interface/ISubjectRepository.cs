using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ISubjectRepository
    {
        Subject CreateAsync(Subject subject);
        Subject UpdateAsync(Subject subject);
        Task DeleteAsync(Subject subject);

        Task<Subject> GetById(int id);
        Task<IEnumerable<Subject>> GetAllAsync();
    }
}
