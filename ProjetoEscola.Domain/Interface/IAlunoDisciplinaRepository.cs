using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IAlunoDisciplinaRepository
    {
        AlunoDisciplina CreateAsync(AlunoDisciplina student);
        AlunoDisciplina UpdateAsync(AlunoDisciplina student);
        Task DeleteAsync(AlunoDisciplina studentSubject);

        Task<IEnumerable<AlunoDisciplina>> GetAllAsync();
        Task<IEnumerable<AlunoDisciplina>> GetAllAsync(int id);
        Task<AlunoDisciplina> GetByIdAsync(int id);
        Task<AlunoDisciplina> GetByStudentIdAsync(int id);
        Task<AlunoDisciplina> GetBySubjectIdAsync(int id);
    }
}
