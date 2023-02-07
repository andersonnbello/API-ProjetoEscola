using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Domain.Interface
{
    public interface IAlunoSerieRepository
    {
        AlunoSerie CreateAsync(AlunoSerie studentSerie);
        AlunoSerie UpdateAsync(AlunoSerie studentSerie);
        Task DeleteAsync(AlunoSerie studentSerie);

        Task<IEnumerable<AlunoSerie>> GetAllAsync();
        Task<AlunoSerie> GetByIdAsync(int id);
        Task<AlunoSerie> GetByStudentIdAsync(int id);
    }
}
