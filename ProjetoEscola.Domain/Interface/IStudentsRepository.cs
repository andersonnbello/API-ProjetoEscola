using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IStudentsRepository
    {
        Student CreateAsync(Student students);
        Student UpdateAsync(Student students);
        Task DeleteAsync(Student students);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student> GetByIdAsync(int id);
        Task<Student> GetByCPFAsync(string cpf);
        Task<Student> GetByRGAsync(string rg);
    }
}
