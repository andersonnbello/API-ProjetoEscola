using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoRepository _addressRepository;

        public EnderecoService(IMapper mapper, IEnderecoRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public ResultService<EnderecoDTO> CreateAsync(EnderecoDTO addressDTO)
        {
            if (addressDTO == null)
                return ResultService.Fail<EnderecoDTO>("Objeto deve ser informado!");

            var validation = new AddressDTOValidation().Validate(addressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<EnderecoDTO>("Problemas na validação dos campos!", validation);

            var addressEntity = _mapper.Map<Endereco>(addressDTO);

            _addressRepository.CreateAsync(addressEntity);

            return ResultService.Ok<EnderecoDTO>(_mapper.Map<EnderecoDTO>(addressEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var address = await _addressRepository.GetById(id);
            if (address == null)
                return ResultService.Fail("Cidade não encontrado!");

            await _addressRepository.DeleteAsync(address);

            return ResultService.Ok($"Cidade {address.NomeEndereco} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<EnderecoDTO>>> GetAllAsync()
        {
            var listAddress = await _addressRepository.GetAllAsync();
            if (listAddress == null)
                return ResultService.Fail<IEnumerable<EnderecoDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<EnderecoDTO>>(_mapper.Map<IEnumerable<EnderecoDTO>>(listAddress));
        }

        public async Task<ResultService<EnderecoDTO>> GetById(int id)
        {
            var address = await _addressRepository.GetById(id);
            if (address == null)
                return ResultService.Fail<EnderecoDTO>("Endereço não encontrado!");

            return ResultService.Ok<EnderecoDTO>(_mapper.Map<EnderecoDTO>(address));
        }

        public async Task<ResultService<EnderecoDTO>> GetByNameAsync(string? addressName)
        {
            var address = await _addressRepository.GetByName(addressName);
            if (address == null)
                return ResultService.Fail<EnderecoDTO>("Endereço não encontrado!");

            return ResultService.Ok<EnderecoDTO>(_mapper.Map<EnderecoDTO>(address));
        }

        public async Task<ResultService> UpdateAsync(EnderecoDTO addressDTO)
        {
            if (addressDTO == null)
                return ResultService.Fail<EnderecoDTO>("Objeto deve ser informado!");

            var validation = new AddressDTOValidation().Validate(addressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<EnderecoDTO>("Problemas na validação dos campos!", validation);

            var address = await _addressRepository.GetById(addressDTO.Id);
            if (address == null)
                return ResultService.Fail<EnderecoDTO>("Cidade não encontrado!");

            address = _mapper.Map<EnderecoDTO, Endereco>(addressDTO, address);

            _addressRepository.UpdateAsync(address);

            return ResultService.Ok($"Cidade {address.NomeEndereco} atualizado com sucesso!");
        }
    }
}
