using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Estado> _repositoryBase;

        public EstadoRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Estado>(_context);
        }

        public Estado CreateAsync(Estado state)
        {
            return state = _repositoryBase.Insert(state);
        }

        public async Task DeleteAsync(Estado state)
        {
            Expression<Func<Estado, bool>> expressionFiltro = (x => x.Id == state.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Estado>> GetAllAsync()
        {
            List<Estado> listStates = new List<Estado>();
            listStates = await _repositoryBase.Select().OrderBy(x => x.NomeEstado).ToListAsync();

            return listStates;
        }

        public async Task<Estado> GetById(int id)
        {
            Expression<Func<Estado, bool>> expressiolFiltro = (x => x.Id == id);
            Estado state = null;

            state = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return state;
        }

        public async Task<Estado> GetByNameAsync(string stateName)
        {
            Expression<Func<Estado, bool>> expressionFiltro = (x => x.NomeEstado == stateName);
            Estado state = null;

            state = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return state;
        }

        public Estado UpdateAsync(Estado state)
        {
            _repositoryBase.Update(state);

            return state;
        }
    }
}
