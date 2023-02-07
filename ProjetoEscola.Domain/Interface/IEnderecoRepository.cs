using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IEnderecoRepository
    {
        Endereco CreateAsync(Endereco address);
        Endereco UpdateAsync(Endereco address);
        Task DeleteAsync(Endereco address);

        Task<Endereco> GetById(int id);
        Task<Endereco> GetByName(string? addressName);
        Task<IEnumerable<Endereco>> GetAllAsync();
    }
}
