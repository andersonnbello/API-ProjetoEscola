using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Subject> _repositoryBase;

        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Subject>(_context);
        }

        public Subject CreateAsync(Subject subject)
        {
            Subject subject_ = null;
            subject_ = _repositoryBase.Insert(subject);

            return subject_;
        }

        public async Task DeleteAsync(Subject subject)
        {
            Expression<Func<Subject, bool>> expressionFiltro = (x => x.Id == subject.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(subject);
            }
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            List<Subject> listSubject = new List<Subject>();
            listSubject = await _repositoryBase.Select().ToListAsync();

            return listSubject;
        }

        public async Task<Subject> GetById(int id)
        {
            Subject subject = null;
            Expression<Func<Subject, bool>> expressionFiltro = (x => x.Id == id);

            subject = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return subject;
        }

        public Subject UpdateAsync(Subject subject)
        {
            _repositoryBase.Update(subject);

            return subject;
        }
    }
}
