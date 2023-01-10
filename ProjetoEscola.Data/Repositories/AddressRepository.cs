using Microsoft.EntityFrameworkCore;
using ProjetoEscola.Data.Context;
using ProjetoEscola.Data.Repositories.Base;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;
using ProjetoEscola.Domain.Interface.Base;
using System.Linq.Expressions;

namespace ProjetoEscola.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryBase<Address> _repositoryBase;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
            _repositoryBase = new RepositoryBase<Address>(_context);
        }

        public Address CreateAsync(Address address)
        {
            return address = _repositoryBase.Insert(address);
        }

        public async Task DeleteAsync(Address address)
        {
            Expression<Func<Address, bool>> expressionFiltro = (x => x.Id == address.Id);
            var response = await _repositoryBase.Select(expressionFiltro).FirstOrDefaultAsync();
            if (response != null)
            {
                _repositoryBase.Delete(response);
            }
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            List<Address> listAddress = new List<Address>();

            listAddress = await _repositoryBase.Select().OrderBy(x => x.AddressName).ToListAsync();

            return listAddress;
        }

        public async Task<Address> GetById(int id)
        {
            Expression<Func<Address, bool>> expressiolFiltro = (x => x.Id == id);
            Address address = null;

            address = await _repositoryBase.Select(expressiolFiltro).FirstOrDefaultAsync();

            return address;
        }

        public Address UpdateAsync(Address address)
        {
            _repositoryBase.Update(address);

            return address;
        }
    }
}
