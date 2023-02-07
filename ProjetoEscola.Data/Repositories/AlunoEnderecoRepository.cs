using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class AlunoEnderecoRepository : IAlunoEnderecoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<AlunoEndereco> _repositoryBase;

        public AlunoEnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<AlunoEndereco>(_context);
        }

        public AlunoEndereco CreateAsync(AlunoEndereco studentsAddress)
        {
            return studentsAddress = _repositoryBase.Insert(studentsAddress);
        }

        public async Task DeleteAsync(AlunoEndereco studentsAddress)
        {
            Expression<Func<AlunoEndereco, bool>> expressionFiltro = (x => x.Id == studentsAddress.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<List<AlunoEndereco>> GetAllAsync()
        {
            List<AlunoEndereco> listStudentsAddress = new List<AlunoEndereco>();
            string[] includes = new string[] { "Aluno", "Cidade", "Estado", "Endereco" };

            listStudentsAddress = await _repositoryBase.Select(includes).OrderBy(x => x.Id).ToListAsync();

            return listStudentsAddress;
        }

        public async Task<AlunoEndereco> GetByIdAsync(int id)
        {
            AlunoEndereco studentAddress = null;
            string[] includes = new string[] { "Aluno", "Cidade", "Estado", "Endereco" };
            Expression<Func<AlunoEndereco, bool>> expressionFiltro = (x => x.Id == id);

            studentAddress = await _repositoryBase.Select(expressionFiltro, includes).FirstOrDefaultAsync();

            return studentAddress;
         }

        public async Task<AlunoEndereco> GetByStudentIdAsync(int id)
        {
            AlunoEndereco studentsSeries = null;
            Expression<Func<AlunoEndereco, bool>> expressionFiltro = (x => x.AlunoId == id);

            studentsSeries = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return studentsSeries;
        }

        public AlunoEndereco UpdateAsync(AlunoEndereco studentAddress)
        {
            _repositoryBase.Update(studentAddress);

            return studentAddress;
        }
    }
}
