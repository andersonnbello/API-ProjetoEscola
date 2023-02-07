using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IProfessorRepository
    {
        Professor CreateAsync(Professor teacher);
        Professor UpdateAsync(Professor teacher);
        Task DeleteAync(Professor teacher);

        Task<List<Professor>> GetAllAsync();
        Task<Professor> GetByIdAsync(int id);
    }
}
