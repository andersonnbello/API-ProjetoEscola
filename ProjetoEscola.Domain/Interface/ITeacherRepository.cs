using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ITeacherRepository
    {
        Teacher CreateAsync(Teacher teacher);
        Teacher UpdateAsync(Teacher teacher);
        Task DeleteAync(Teacher teacher);

        Task<List<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
    }
}
