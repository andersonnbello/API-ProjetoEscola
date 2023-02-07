using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IAlunoEnderecoRepository
    {
        AlunoEndereco CreateAsync(AlunoEndereco studentsAddress);
        AlunoEndereco UpdateAsync(AlunoEndereco studentsAddress);
        Task DeleteAsync(AlunoEndereco studentsAddress);

        Task<AlunoEndereco> GetByStudentIdAsync(int id);
        Task<List<AlunoEndereco>> GetAllAsync();
        Task<AlunoEndereco> GetByIdAsync(int id);
    }
}
