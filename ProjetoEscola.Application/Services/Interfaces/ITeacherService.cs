using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ITeacherService
    {
        ResultService<TeachersDTO> CreateAsync(TeachersDTO teachersDTO);
        Task<ResultService> UpdateAsync(TeachersDTO teachersDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<List<TeachersDTO>>> GetAllAsync();
        Task<ResultService<TeachersDTO>> GetByIdAsync(int id);
    }
}
