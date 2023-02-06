using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IAddressRepository
    {
        Address CreateAsync(Address address);
        Address UpdateAsync(Address address);
        Task DeleteAsync(Address address);

        Task<Address> GetById(int id);
        Task<Address> GetByName(string? addressName);
        Task<IEnumerable<Address>> GetAllAsync();
    }
}
