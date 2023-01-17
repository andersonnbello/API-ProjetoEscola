using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IStudentsAddressService
    {
        ResultService<StudentsAddressDTO> CreateAsync(StudentsAddressDTO studentsAddressDTO);
        Task<ResultService> UpdateAsync(StudentsAddressDTO studentsAddressDTO);
        Task<ResultService> DeleteAsync(int id);

        Task<ResultService<List<StudentsAddressDTO>>> GetAllAsync();
        Task<ResultService<StudentsAddressDTO>> GetByIdAsync(int id);
        Task<ResultService<StudentsAddressDTO>> GetByStudentIdAsync(int id);
    }
}
