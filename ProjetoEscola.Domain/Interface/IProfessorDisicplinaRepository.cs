using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IProfessorDisicplinaRepository
    {
        ProfessorDisciplina CreateAsync(ProfessorDisciplina teacherSubject);
        ProfessorDisciplina UpdateAsync(ProfessorDisciplina teacherSubject);
        Task DeleteAsync(ProfessorDisciplina teacherSubject);

        Task<IEnumerable<ProfessorDisciplina>> GetAllAsync();
        Task<ProfessorDisciplina> GetByIdAsync(int id);
        Task<ProfessorDisciplina> GetBySubjectIdAsync(int id);
        Task<ProfessorDisciplina> GetByTeacherIdAsync(int id);
    }
}
