using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class StudentSerieRepository : IStudentSerieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<StudentSerie> _repositoryBase;

        public StudentSerieRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<StudentSerie>(_context);
        }

        public StudentSerie CreateAsync(StudentSerie studentSerie)
        {
            return studentSerie = _repositoryBase.Insert(studentSerie);
        }

        public async Task DeleteAsync(StudentSerie studentSerie)
        {
            Expression<Func<StudentSerie, bool>> expressionFiltro = (x => x.Id == studentSerie.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<StudentSerie>> GetAllAsync()
        {
            List<StudentSerie> listStudentsSeries = new List<StudentSerie>();
            string[] includes = new string[] { "Students", "Series" };

            listStudentsSeries = await _repositoryBase.Select(includes).ToListAsync();

            return listStudentsSeries;
        }

        public async Task<StudentSerie> GetByStudentIdAsync(int id)
        {
            StudentSerie studentsSeries = null;
            Expression<Func<StudentSerie, bool>> expressionFiltro = (x => x.StudentId == id);

            studentsSeries = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentsSeries;
        }

        public async Task<StudentSerie> GetByIdAsync(int id)
        {
            StudentSerie studentSubject = null;
            string[] includes = new string[] { "Students", "Series" };
            Expression<Func<StudentSerie, bool>> expressionFiltro = (x => x.Id == id);

            studentSubject = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return studentSubject;
        }

        public StudentSerie UpdateAsync(StudentSerie studentSerie)
        {
            _repositoryBase.Update(studentSerie);

            return studentSerie;
        }
    }
}
