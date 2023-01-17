using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentsService
    {
        Task<ResultService<IEnumerable<StudentsDTO>>> GetAllAsync();
        Task<ResultService<StudentsDTO>> CreateAsync(StudentsDTO studentsDTO);
        Task<ResultService> UpdateAsync(StudentsDTO studentsDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<StudentsDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentsDTO>> GetByCPFAsync(string cpf);
        Task<ResultService<StudentsDTO>> GetByRGAsync(string rg);
    }
}
