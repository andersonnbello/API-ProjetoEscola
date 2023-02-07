using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        ResultService<EnderecoDTO> CreateAsync(EnderecoDTO addressDTO);
        Task<ResultService> UpdateAsync(EnderecoDTO addressDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<EnderecoDTO>>> GetAllAsync();
        Task<ResultService<EnderecoDTO>> GetById(int id);
        Task<ResultService<EnderecoDTO>> GetByNameAsync(string? addressName);
    }
}
