using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ITeacherSubjectRepository
    {
        Task<IEnumerable<TeacherSubject>> GetAllAsync();
        TeacherSubject CreateAsync(TeacherSubject teacherSubject);
        TeacherSubject UpdateAsync(TeacherSubject teacherSubject);
        Task<TeacherSubject> GetByIdAsync(int id);
        Task DeleteAsync(TeacherSubject teacherSubject);
    }
}
