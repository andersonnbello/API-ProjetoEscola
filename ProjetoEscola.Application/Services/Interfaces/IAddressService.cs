using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Services.Interfaces
{
    public interface IAddressService
    {
        ResultService<AddressDTO> CreateAsync(AddressDTO addressDTO);
        Task<ResultService<IEnumerable<AddressDTO>>> GetAllAsync();
        Task<ResultService<AddressDTO>> GetById(int id);
        Task<ResultService> UpdateAsync(AddressDTO addressDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
