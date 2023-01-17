using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface ISubjectService
    {
        ResultService<SubjectsDTO> CreateAsync(SubjectsDTO subjectsDTO);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService> UpdateAsync(SubjectsDTO subjectsDTO);

        Task<ResultService<IEnumerable<SubjectsDTO>>> GetAllAsync();
        Task<ResultService<SubjectsDTO>> GetByIdAsync(int id);
    }
}
