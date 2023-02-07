using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Professor> _repositoryBase;

        public ProfessorRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Professor>(_context);
        }

        public Professor CreateAsync(Professor teacher)
        {
            Professor teacher_ = null;
            teacher = _repositoryBase.Insert(teacher);

            return teacher_;
        }

        public async Task DeleteAync(Professor teachers)
        {
            Expression<Func<Professor, bool>> expressionFiltro = (x => x.Id == teachers.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            List<Professor> listTeacher = new List<Professor>();
            listTeacher = await _repositoryBase.Select().ToListAsync();

            return listTeacher;
        }

        public async Task<Professor> GetByIdAsync(int id)
        {
            Professor teacher = null;
            Expression<Func<Professor, bool>> expressionFiltro = (x => x.Id == id);

            teacher = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return teacher;
        }

        public Professor UpdateAsync(Professor teacher)
        {
            _repositoryBase.Update(teacher);

            return teacher;
        }
    }
}
