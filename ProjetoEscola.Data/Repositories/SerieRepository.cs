using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class SerieRepository : ISerieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Serie> _repositoryBase;

        public SerieRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Serie>(_context);
        }

        public Serie CreateAsync(Serie serie)
        {
            return serie = _repositoryBase.Insert(serie);

        }

        public async Task DeleteAsync(Serie serie)
        {
            Expression<Func<Serie, bool>> expressionFiltro = (x => x.Id == serie.Id);

            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Serie>> GetAllAsync()
        {
            //var resultado = await _repositoryBase.Select().GroupBy(x => x.Categoria).Select(x => new { x.Key, Name = x.Select(x => x.Name) }).ToListAsync();

            List<Serie> listSeries = new List<Serie>();
            listSeries = await _repositoryBase.Select().OrderBy(x => x.NomeSerie).ToListAsync();

            return listSeries;
        }

        public async Task<Serie> GetById(int id)
        {
            Expression<Func<Serie, bool>> expressiolFiltro = (x => x.Id == id);
            Serie serie = null;

            serie = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return serie;
        }

        public Serie UpdateAsync(Serie serie)
        {
            _repositoryBase.Update(serie);

            return serie;
        }
    }
}
