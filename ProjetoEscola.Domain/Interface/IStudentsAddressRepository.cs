using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IStudentsAddressRepository
    {
        StudentAddress CreateAsync(StudentAddress studentsAddress);
        StudentAddress UpdateAsync(StudentAddress studentsAddress);
        Task DeleteAsync(StudentAddress studentsAddress);

        Task<StudentAddress> GetByStudentIdAsync(int id);
        Task<List<StudentAddress>> GetAllAsync();
        Task<StudentAddress> GetByIdAsync(int id);
    }
}
