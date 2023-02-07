using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class AlunoDisciplinaRepository : IAlunoDisciplinaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<AlunoDisciplina> _repositoryBase;

        public AlunoDisciplinaRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<AlunoDisciplina>(_context);
        }

        public AlunoDisciplina CreateAsync(AlunoDisciplina studentSubject)
        {
            return studentSubject = _repositoryBase.Insert(studentSubject);
        }

        public async Task DeleteAsync(AlunoDisciplina studentSubject)
        {
            Expression<Func<AlunoDisciplina, bool>> expressionFiltro = (x => x.Id == studentSubject.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<AlunoDisciplina>> GetAllAsync()
        {
            List<AlunoDisciplina> listStudentsSubjects = new List<AlunoDisciplina>();

            string[] includes = new string[] { "Aluno", "Disciplina" };

            listStudentsSubjects = await _repositoryBase.Select(includes).ToListAsync();

            return listStudentsSubjects;
        }

        public async Task<IEnumerable<AlunoDisciplina>> GetAllAsync(int id)
        {
            List<AlunoDisciplina> listStudentsSubjects = new List<AlunoDisciplina>();
            Expression<Func<AlunoDisciplina, bool>> expressionFiltro = (x => x.AlunoId == id);
            string[] includes = new string[] { "Aluno", "Disciplina" };

            listStudentsSubjects = await _repositoryBase.Select(expressionFiltro, includes).ToListAsync();

            return listStudentsSubjects;
        }

        public async Task<AlunoDisciplina> GetByIdAsync(int id)
        {
            AlunoDisciplina studentSubject = null;
            string[] includes = new string[] {"Aluno", "Disciplina" };
            Expression<Func<AlunoDisciplina, bool>> expressionFiltro = (x => x.Id == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return studentSubject;
        }

        public async Task<AlunoDisciplina> GetByStudentIdAsync(int id)
        {
            AlunoDisciplina studentSubject = null;
            Expression<Func<AlunoDisciplina, bool>> expressionFiltro = (x => x.AlunoId == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentSubject;
        }

        public async Task<AlunoDisciplina> GetBySubjectIdAsync(int id)
        {
            AlunoDisciplina studentSubject = null;
            Expression<Func<AlunoDisciplina, bool>> expressionFiltro = (x => x.DisciplinaId == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentSubject;
        }

        public AlunoDisciplina UpdateAsync(AlunoDisciplina studentSubject)
        {
            _repositoryBase.Update(studentSubject);

            return studentSubject;
        }
    }
}
