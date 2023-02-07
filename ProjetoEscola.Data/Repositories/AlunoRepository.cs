using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Aluno> _repositoryBase;

        public AlunoRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Aluno>(_context);
        }

        public Aluno CreateAsync(Aluno students)
        {
            return students = _repositoryBase.Insert(students);
        }

        public async Task DeleteAsync(Aluno students)
        {
            Expression<Func<Aluno, bool>> expressionFiltro = (x => x.Id == students.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync()
        {
            List<Aluno> listStudents = new List<Aluno>();
            Expression<Func<Aluno, bool>> expressionFiltro = (x => x.isAtivo == true);

            listStudents = await _repositoryBase.Select(expressionFiltro).OrderBy(x => x.NomeCompleto).ToListAsync();

            return listStudents;
        }

        public async Task<Aluno> GetByCPFAsync(string cpf)
        {
            Aluno student = null;
            Expression<Func<Aluno, bool>> expressionFiltro = (x => x.Cpf == cpf);

            student = await _repositoryBase.Select().FirstOrDefaultAsync(expressionFiltro);

            return student;
        }

        public async Task<Aluno> GetByRGAsync(string rg)
        {
            Aluno student = null;
            Expression<Func<Aluno, bool>> expressionFiltro = (x => x.Rg == rg);

            student = await _repositoryBase.Select().FirstOrDefaultAsync(expressionFiltro);

            return student;
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            Aluno response;
            Expression<Func<Aluno, bool>> expressionFiltro = (x => x.Id == id);
            response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return response;
        }

        public Aluno UpdateAsync(Aluno students)
        {
            _repositoryBase.Update(students);

            return students;
        }
    }
}
