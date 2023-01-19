using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<TeacherSubject> _repositoryBase;

        public TeacherSubjectRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<TeacherSubject>(_context);
        }

        public async Task<IEnumerable<TeacherSubject>> GetAllAsync()
        {
            List<TeacherSubject> listTeahcerSubject = new List<TeacherSubject>();
            string[] includes = new string[] { "Subjects", "Teachers" };

            listTeahcerSubject = await _repositoryBase.Select(includes).ToListAsync();

            return listTeahcerSubject;
        }

        public async Task<TeacherSubject> GetByIdAsync(int id)
        {
            TeacherSubject teacherSubject = null;
            string[] includes = new string[] { "Subjects", "Teachers" };
            Expression<Func<TeacherSubject, bool>> expressionFiltro = (x => x.Id == id);

            teacherSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return teacherSubject;
        }

        public TeacherSubject UpdateAsync(TeacherSubject teacherSubject)
        {
            _repositoryBase.Update(teacherSubject);

            return teacherSubject;
        }

        public TeacherSubject CreateAsync(TeacherSubject teacherSubject)
        {
            TeacherSubject teacherSubject_ = null;

            teacherSubject_ = _repositoryBase.Insert(teacherSubject);

            return teacherSubject_;
        }

        public async Task DeleteAsync(TeacherSubject teacherSubject)
        {
            Expression<Func<TeacherSubject, bool>> expressionFiltro = (x => x.Id == teacherSubject.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(teacherSubject);
            }
        }

        public async Task<TeacherSubject> GetBySubjectIdAsync(int id)
        {
            TeacherSubject teacherSubject = null;
            string[] includes = new string[] { "Subjects", "Teachers" };
            Expression<Func<TeacherSubject, bool>> expressionFiltro = (x => x.SubjectId == id);

            teacherSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return teacherSubject;
        }

        public async Task<TeacherSubject> GetByTeacherIdAsync(int id)
        {
            TeacherSubject teacherSubject = null;
            string[] includes = new string[] { "Subjects", "Teachers" };
            Expression<Func<TeacherSubject, bool>> expressionFiltro = (x => x.SubjectId == id);

            teacherSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return teacherSubject;
        }
    }
}
