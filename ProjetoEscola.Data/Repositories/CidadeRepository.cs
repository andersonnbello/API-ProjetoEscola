using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Cidade> _repositoryBase;

        public CidadeRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Cidade>(_context);
        }

        public Cidade CreateAsync(Cidade city)
        {
            return city = _repositoryBase.Insert(city);
        }

        public async Task DeleteAsync(Cidade city)
        {
            Expression<Func<Cidade, bool>> expressionFiltro = (x => x.Id == city.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Cidade>> GetAllAsync()
        {
            List<Cidade> listStates = new List<Cidade>();

            listStates = await _repositoryBase.Select().OrderBy(x => x.NomeCidade).ToListAsync();

            return listStates;
        }

        public async Task<Cidade> GetById(int id)
        {
            Expression<Func<Cidade, bool>> expressiolFiltro = (x => x.Id == id);
            Cidade city = null;

            city = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return city;
        }

        public async Task<Cidade> GetByNameAsync(string cityName)
        {
            Expression<Func<Cidade, bool>> expressiolFiltro = (x => x.NomeCidade == cityName);
            Cidade city = null;

            city = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return city;
        }

        public Cidade UpdateAsync(Cidade city)
        {
            _repositoryBase.Update(city);

            return city;
        }
    }
}
