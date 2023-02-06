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
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<State> _repositoryBase;

        public StateRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<State>(_context);
        }

        public State CreateAsync(State state)
        {
            return state = _repositoryBase.Insert(state);
        }

        public async Task DeleteAsync(State state)
        {
            Expression<Func<State, bool>> expressionFiltro = (x => x.Id == state.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            List<State> listStates = new List<State>();
            listStates = await _repositoryBase.Select().OrderBy(x => x.StateName).ToListAsync();

            return listStates;
        }

        public async Task<State> GetById(int id)
        {
            Expression<Func<State, bool>> expressiolFiltro = (x => x.Id == id);
            State state = null;

            state = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return state;
        }

        public async Task<State> GetByNameAsync(string stateName)
        {
            Expression<Func<State, bool>> expressionFiltro = (x => x.StateName == stateName);
            State state = null;

            state = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();

            return state;
        }

        public State UpdateAsync(State state)
        {
            _repositoryBase.Update(state);

            return state;
        }
    }
}
