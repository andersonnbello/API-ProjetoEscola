using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IAlunoEnderecoService
    {
        ResultService<AlunoEnderecoDTO> CreateAsync(AlunoEnderecoDTO studentsAddressDTO);
        Task<ResultService> UpdateAsync(AlunoEnderecoDTO studentsAddressDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<List<AlunoEnderecoDTO>>> GetAllAsync();
        Task<ResultService<AlunoEnderecoDTO>> GetByIdAsync(int id);
        Task<ResultService<AlunoEnderecoDTO>> GetByStudentIdAsync(int id);
    }
}
