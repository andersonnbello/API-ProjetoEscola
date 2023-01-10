using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IStudentSerieRepository
    {
        StudentSerie CreateAsync(StudentSerie studentSerie);
        StudentSerie UpdateAsync(StudentSerie studentSerie);
        Task<IEnumerable<StudentSerie>> GetAllAsync();
        Task<StudentSerie> GetByIdAsync(int id);
        Task<StudentSerie> GetByStudentIdAsync(int id);
        Task DeleteAsync(StudentSerie studentSerie);
    }
}
