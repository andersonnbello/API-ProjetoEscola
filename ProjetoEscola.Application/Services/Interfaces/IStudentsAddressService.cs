using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentsAddressService
    {
        Task<ResultService<List<StudentsAddressDTO>>> GetAllAsync();
        ResultService<StudentsAddressDTO> CreateAsync(StudentsAddressDTO studentsAddressDTO);
        Task<ResultService> UpdateAsync(StudentsAddressDTO studentsAddressDTO);
        Task<ResultService<StudentsAddressDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentsAddressDTO>> GetByStudentIdAsync(int id);
        Task<ResultService> DeleteAsync(int id);
    }
}
