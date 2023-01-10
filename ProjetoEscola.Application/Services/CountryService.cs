using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountryService(IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public ResultService<CountryDTO> CreateAsync(CountryDTO countryDTO)
        {
            if (countryDTO == null)
                return ResultService.Fail<CountryDTO>("Objeto deve ser informado!");

            var validation = new CountryDTOValidation().Validate(countryDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<CountryDTO>("Problemas na validação dos campos!", validation);

            var countryEntity = _mapper.Map<Country>(countryDTO);

            _countryRepository.CreateAsync(countryEntity);

            return ResultService.Ok<CountryDTO>(_mapper.Map<CountryDTO>(countryEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var country = await _countryRepository.GetById(id);
            if (country == null)
                return ResultService.Fail("País não encontrado!");

            await _countryRepository.DeleteAsync(country);

            return ResultService.Ok($"País {country.CountryName} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<CountryDTO>>> GetAllAsync()
        {
            var listCountrys = await _countryRepository.GetAllAsync();
            if (listCountrys == null)
                return ResultService.Fail<IEnumerable<CountryDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<CountryDTO>>(_mapper.Map<IEnumerable<CountryDTO>>(listCountrys));
        }

        public async Task<ResultService<CountryDTO>> GetById(int id)
        {
            var country = await _countryRepository.GetById(id);
            if (country == null)
                return ResultService.Fail<CountryDTO>("País não encontrado!");

            return ResultService.Ok<CountryDTO>(_mapper.Map<CountryDTO>(country));
        }

        public async Task<ResultService> UpdateAsync(CountryDTO countryDTO)
        {
            if (countryDTO == null)
                return ResultService.Fail<CountryDTO>("Objeto deve ser informado!");

            var validation = new CountryDTOValidation().Validate(countryDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<CountryDTO>("Problemas na validação dos campos!", validation);

            var country = await _countryRepository.GetById(countryDTO.Id);
            if (country == null)
                return ResultService.Fail<CountryDTO>("Paíe não encontrado!");

            country = _mapper.Map<CountryDTO, Country>(countryDTO, country);

            _countryRepository.UpdateAsync(country);

            return ResultService.Ok($"País {country.CountryName} atualizado com sucesso!");
        }
    }
}
