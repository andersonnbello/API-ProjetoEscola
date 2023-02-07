using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Disciplina> _repositoryBase;

        public DisciplinaRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Disciplina>(_context);
        }

        public Disciplina CreateAsync(Disciplina subject)
        {
            Disciplina subject_ = null;
            subject_ = _repositoryBase.Insert(subject);

            return subject_;
        }

        public async Task DeleteAsync(Disciplina subject)
        {
            Expression<Func<Disciplina, bool>> expressionFiltro = (x => x.Id == subject.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(subject);
            }
        }

        public async Task<IEnumerable<Disciplina>> GetAllAsync()
        {
            List<Disciplina> listSubject = new List<Disciplina>();
            listSubject = await _repositoryBase.Select().ToListAsync();

            return listSubject;
        }

        public async Task<Disciplina> GetById(int id)
        {
            Disciplina subject = null;
            Expression<Func<Disciplina, bool>> expressionFiltro = (x => x.Id == id);

            subject = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return subject;
        }

        public Disciplina UpdateAsync(Disciplina subject)
        {
            _repositoryBase.Update(subject);

            return subject;
        }
    }
}
