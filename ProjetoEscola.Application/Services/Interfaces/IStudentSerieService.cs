using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentSerieService
    {
        ResultService<StudentSerieDTO> CreateAsync(StudentSerieDTO studentSerieDTO);
        Task<ResultService> UpdateAsync(StudentSerieDTO studentSerieDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<IEnumerable<StudentSerieDTO>>> GetAllAsync();
        Task<ResultService<StudentSerieDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentSerieDTO>> GetByStudentIdAsync(int id);
    }
}
