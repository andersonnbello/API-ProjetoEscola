using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface ITeacherSubjectRepository
    {
        TeacherSubject CreateAsync(TeacherSubject teacherSubject);
        TeacherSubject UpdateAsync(TeacherSubject teacherSubject);
        Task DeleteAsync(TeacherSubject teacherSubject);

        Task<IEnumerable<TeacherSubject>> GetAllAsync();
        Task<TeacherSubject> GetByIdAsync(int id);
        Task<TeacherSubject> GetBySubjectIdAsync(int id);
        Task<TeacherSubject> GetByTeacherIdAsync(int id);
    }
}
