using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IAlunoRepository
    {
        Aluno CreateAsync(Aluno students);
        Aluno UpdateAsync(Aluno students);
        Task DeleteAsync(Aluno students);

        Task<IEnumerable<Aluno>> GetAllAsync();

        Task<Aluno> GetByIdAsync(int id);
        Task<Aluno> GetByCPFAsync(string cpf);
        Task<Aluno> GetByRGAsync(string rg);
    }
}
