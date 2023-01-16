using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IStudentsSubjectsRepository
    {
        StudentSubject CreateAsync(StudentSubject student);
        StudentSubject UpdateAsync(StudentSubject student);
        Task<IEnumerable<StudentSubject>> GetAllAsync();
        Task<IEnumerable<StudentSubject>> GetAllAsync(int id);
        Task<StudentSubject> GetByIdAsync(int id);
        Task<StudentSubject> GetByStudentIdAsync(int id);
        Task<StudentSubject> GetBySubjectIdAsync(int id);
        Task DeleteAsync(StudentSubject studentSubject);
    }
}
