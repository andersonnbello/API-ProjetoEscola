using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public ResultService<AddressDTO> CreateAsync(AddressDTO addressDTO)
        {
            if (addressDTO == null)
                return ResultService.Fail<AddressDTO>("Objeto deve ser informado!");

            var validation = new AddressDTOValidation().Validate(addressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AddressDTO>("Problemas na validação dos campos!", validation);

            var addressEntity = _mapper.Map<Address>(addressDTO);

            _addressRepository.CreateAsync(addressEntity);

            return ResultService.Ok<AddressDTO>(_mapper.Map<AddressDTO>(addressEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var address = await _addressRepository.GetById(id);
            if (address == null)
                return ResultService.Fail("Cidade não encontrado!");

            await _addressRepository.DeleteAsync(address);

            return ResultService.Ok($"Cidade {address.AddressName} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<AddressDTO>>> GetAllAsync()
        {
            var listAddress = await _addressRepository.GetAllAsync();
            if (listAddress == null)
                return ResultService.Fail<IEnumerable<AddressDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<AddressDTO>>(_mapper.Map<IEnumerable<AddressDTO>>(listAddress));
        }

        public async Task<ResultService<AddressDTO>> GetById(int id)
        {
            var address = await _addressRepository.GetById(id);
            if (address == null)
                return ResultService.Fail<AddressDTO>("Endereço não encontrado!");

            return ResultService.Ok<AddressDTO>(_mapper.Map<AddressDTO>(address));
        }

        public async Task<ResultService<AddressDTO>> GetByNameAsync(string? addressName)
        {
            var address = await _addressRepository.GetByName(addressName);
            if (address == null)
                return ResultService.Fail<AddressDTO>("Endereço não encontrado!");

            return ResultService.Ok<AddressDTO>(_mapper.Map<AddressDTO>(address));
        }

        public async Task<ResultService> UpdateAsync(AddressDTO addressDTO)
        {
            if (addressDTO == null)
                return ResultService.Fail<AddressDTO>("Objeto deve ser informado!");

            var validation = new AddressDTOValidation().Validate(addressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AddressDTO>("Problemas na validação dos campos!", validation);

            var address = await _addressRepository.GetById(addressDTO.Id);
            if (address == null)
                return ResultService.Fail<AddressDTO>("Cidade não encontrado!");

            address = _mapper.Map<AddressDTO, Address>(addressDTO, address);

            _addressRepository.UpdateAsync(address);

            return ResultService.Ok($"Cidade {address.AddressName} atualizado com sucesso!");
        }
    }
}
