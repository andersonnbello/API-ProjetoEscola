using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class ProfessorDisciplinaRepository : IProfessorDisicplinaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<ProfessorDisciplina> _repositoryBase;

        public ProfessorDisciplinaRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<ProfessorDisciplina>(_context);
        }

        public async Task<IEnumerable<ProfessorDisciplina>> GetAllAsync()
        {
            List<ProfessorDisciplina> listTeahcerSubject = new List<ProfessorDisciplina>();
            string[] includes = new string[] {"Disciplinas", "Professores" };

            listTeahcerSubject = await _repositoryBase.Select(includes).ToListAsync();

            return listTeahcerSubject;
        }

        public async Task<ProfessorDisciplina> GetByIdAsync(int id)
        {
            ProfessorDisciplina teacherSubject = null;
            string[] includes = new string[] { "Disciplinas", "Professores" };
            Expression<Func<ProfessorDisciplina, bool>> expressionFiltro = (x => x.Id == id);

            teacherSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return teacherSubject;
        }

        public ProfessorDisciplina UpdateAsync(ProfessorDisciplina teacherSubject)
        {
            _repositoryBase.Update(teacherSubject);

            return teacherSubject;
        }

        public ProfessorDisciplina CreateAsync(ProfessorDisciplina teacherSubject)
        {
            ProfessorDisciplina teacherSubject_ = null;

            teacherSubject_ = _repositoryBase.Insert(teacherSubject);

            return teacherSubject_;
        }

        public async Task DeleteAsync(ProfessorDisciplina teacherSubject)
        {
            Expression<Func<ProfessorDisciplina, bool>> expressionFiltro = (x => x.Id == teacherSubject.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(teacherSubject);
            }
        }

        public async Task<ProfessorDisciplina> GetBySubjectIdAsync(int id)
        {
            ProfessorDisciplina teacherSubject = null;
            string[] includes = new string[] { "Disciplinas", "Professores" };
            Expression<Func<ProfessorDisciplina, bool>> expressionFiltro = (x => x.DisciplinaId == id);

            teacherSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return teacherSubject;
        }

        public async Task<ProfessorDisciplina> GetByTeacherIdAsync(int id)
        {
            ProfessorDisciplina teacherSubject = null;
            string[] includes = new string[] { "Disciplinas", "Professores" };
            Expression<Func<ProfessorDisciplina, bool>> expressionFiltro = (x => x.DisciplinaId == id);

            teacherSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return teacherSubject;
        }
    }
}
