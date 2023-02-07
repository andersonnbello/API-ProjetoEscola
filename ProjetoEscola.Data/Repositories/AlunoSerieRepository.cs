using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class AlunoSerieRepository : IAlunoSerieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<AlunoSerie> _repositoryBase;

        public AlunoSerieRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<AlunoSerie>(_context);
        }

        public AlunoSerie CreateAsync(AlunoSerie studentSerie)
        {
            return studentSerie = _repositoryBase.Insert(studentSerie);
        }

        public async Task DeleteAsync(AlunoSerie studentSerie)
        {
            Expression<Func<AlunoSerie, bool>> expressionFiltro = (x => x.Id == studentSerie.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<AlunoSerie>> GetAllAsync()
        {
            List<AlunoSerie> listStudentsSeries = new List<AlunoSerie>();
            string[] includes = new string[] { "Alunos", "Series" };

            listStudentsSeries = await _repositoryBase.Select(includes).ToListAsync();

            return listStudentsSeries;
        }

        public async Task<AlunoSerie> GetByStudentIdAsync(int id)
        {
            AlunoSerie studentsSeries = null;
            Expression<Func<AlunoSerie, bool>> expressionFiltro = (x => x.AlunoId == id);

            studentsSeries = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentsSeries;
        }

        public async Task<AlunoSerie> GetByIdAsync(int id)
        {
            AlunoSerie studentSubject = null;
            string[] includes = new string[] { "Alunos", "Series" };
            Expression<Func<AlunoSerie, bool>> expressionFiltro = (x => x.Id == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return studentSubject;
        }

        public AlunoSerie UpdateAsync(AlunoSerie studentSerie)
        {
            _repositoryBase.Update(studentSerie);

            return studentSerie;
        }
    }
}
