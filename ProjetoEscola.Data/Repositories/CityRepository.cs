using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<City> _repositoryBase;

        public CityRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<City>(_context);
        }

        public City CreateAsync(City city)
        {
            return city = _repositoryBase.Insert(city);
        }

        public async Task DeleteAsync(City city)
        {
            Expression<Func<City, bool>> expressionFiltro = (x => x.Id == city.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            List<City> listStates = new List<City>();

            listStates = await _repositoryBase.Select().OrderBy(x => x.CityName).ToListAsync();

            return listStates;
        }

        public async Task<City> GetById(int id)
        {
            Expression<Func<City, bool>> expressiolFiltro = (x => x.Id == id);
            City city = null;

            city = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return city;
        }

        public City UpdateAsync(City city)
        {
            _repositoryBase.Update(city);

            return city;
        }
    }
}
