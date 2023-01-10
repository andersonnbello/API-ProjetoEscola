using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Country> _repositoryBase;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Country>(_context);
        }

        public Country CreateAsync(Country country)
        {
            return country = _repositoryBase.Insert(country);
        }

        public async Task DeleteAsync(Country country)
        {
            Expression<Func<Country, bool>> expressionFiltro = (x => x.Id == country.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            List<Country> listCountrys = new List<Country>();

            listCountrys = await _repositoryBase.Select().OrderBy(x => x.CountryName).ToListAsync();

            return listCountrys;
        }

        public async Task<Country> GetById(int id)
        {
            Expression<Func<Country, bool>> expressiolFiltro = (x => x.Id == id);
            Country country = null;

            country = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return country;
        }

        public Country UpdateAsync(Country country)
        {
            _repositoryBase.Update(country);

            return country;
        }
    }
}
