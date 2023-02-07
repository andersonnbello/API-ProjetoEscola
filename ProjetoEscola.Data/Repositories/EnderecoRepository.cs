using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Endereco> _repositoryBase;

        public EnderecoRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Endereco>(_context);
        }

        public Endereco CreateAsync(Endereco address)
        {
            return address = _repositoryBase.Insert(address);
        }

        public async Task DeleteAsync(Endereco address)
        {
            Expression<Func<Endereco, bool>> expressionFiltro = (x => x.Id == address.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            List<Endereco> listAddress = new List<Endereco>();

            listAddress = await _repositoryBase.Select().OrderBy(x => x.NomeEndereco).ToListAsync();

            return listAddress;
        }

        public async Task<Endereco> GetById(int id)
        {
            Expression<Func<Endereco, bool>> expressiolFiltro = (x => x.Id == id);
            Endereco address = null;

            address = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return address;
        }

        public async Task<Endereco> GetByName(string? addressName)
        {
            Expression<Func<Endereco, bool>> expressiolFiltro = (x => x.NomeEndereco == addressName);
            Endereco address = null;

            address = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return address;
        }

        public Endereco UpdateAsync(Endereco address)
        {
            _repositoryBase.Update(address);

            return address;
        }
    }
}
