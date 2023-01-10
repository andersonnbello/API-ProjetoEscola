using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentSerieService
    {
        Task<ResultService<IEnumerable<StudentSerieDTO>>> GetAllAsync();
        ResultService<StudentSerieDTO> CreateAsync(StudentSerieDTO studentSerieDTO);
        Task<ResultService> UpdateAsync(StudentSerieDTO studentSerieDTO);
        Task<ResultService<StudentSerieDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentSerieDTO>> GetByStudentIdAsync(int id);
        Task<ResultService> DeleteAsync(int id);
    }
}
