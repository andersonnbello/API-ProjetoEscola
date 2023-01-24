using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class StudentsSubjectsRepository : IStudentsSubjectsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<StudentSubject> _repositoryBase;

        public StudentsSubjectsRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<StudentSubject>(_context);
        }

        public StudentSubject CreateAsync(StudentSubject studentSubject)
        {
            return studentSubject = _repositoryBase.Insert(studentSubject);
        }

        public async Task DeleteAsync(StudentSubject studentSubject)
        {
            Expression<Func<StudentSubject, bool>> expressionFiltro = (x => x.Id == studentSubject.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<StudentSubject>> GetAllAsync()
        {
            List<StudentSubject> listStudentsSubjects = new List<StudentSubject>();

            string[] includes = new string[] { "Students", "Subjects" };

            listStudentsSubjects = await _repositoryBase.Select(includes).ToListAsync();

            return listStudentsSubjects;
        }

        public async Task<IEnumerable<StudentSubject>> GetAllAsync(int id)
        {
            List<StudentSubject> listStudentsSubjects = new List<StudentSubject>();
            Expression<Func<StudentSubject, bool>> expressionFiltro = (x => x.StudentId == id);
            string[] includes = new string[] { "Students", "Subjects" };

            listStudentsSubjects = await _repositoryBase.Select(expressionFiltro, includes).ToListAsync();

            return listStudentsSubjects;
        }

        public async Task<StudentSubject> GetByIdAsync(int id)
        {
            StudentSubject studentSubject = null;
            string[] includes = new string[] { "Students", "Subjects" };
            Expression<Func<StudentSubject, bool>> expressionFiltro = (x => x.Id == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return studentSubject;
        }

        public async Task<StudentSubject> GetByStudentIdAsync(int id)
        {
            StudentSubject studentSubject = null;
            Expression<Func<StudentSubject, bool>> expressionFiltro = (x => x.StudentId == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentSubject;
        }

        public async Task<StudentSubject> GetBySubjectIdAsync(int id)
        {
            StudentSubject studentSubject = null;
            Expression<Func<StudentSubject, bool>> expressionFiltro = (x => x.SubjectId == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentSubject;
        }

        public StudentSubject UpdateAsync(StudentSubject studentSubject)
        {
            _repositoryBase.Update(studentSubject);

            return studentSubject;
        }
    }
}
