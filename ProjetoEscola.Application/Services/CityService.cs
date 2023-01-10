using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class CityService : ICityService
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public CityService(IMapper mapper, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public ResultService<CityDTO> CreateAsync(CityDTO cityDTO)
        {
            if (cityDTO == null)
                return ResultService.Fail<CityDTO>("Objeto deve ser informado!");

            var validation = new CityDTOValidation().Validate(cityDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<CityDTO>("Problemas na validação dos campos!", validation);

            var cityEntity = _mapper.Map<City>(cityDTO);

            _cityRepository.CreateAsync(cityEntity);

            return ResultService.Ok<CityDTO>(_mapper.Map<CityDTO>(cityEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var city = await _cityRepository.GetById(id);
            if (city == null)
                return ResultService.Fail("Cidade não encontrado!");

            await _cityRepository.DeleteAsync(city);

            return ResultService.Ok($"Cidade {city.CityName} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<CityDTO>>> GetAllAsync()
        {
            var listCities = await _cityRepository.GetAllAsync();
            if (listCities == null)
                return ResultService.Fail<IEnumerable<CityDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<CityDTO>>(_mapper.Map<IEnumerable<CityDTO>>(listCities));
        }

        public async Task<ResultService<CityDTO>> GetById(int id)
        {
            var state = await _cityRepository.GetById(id);
            if (state == null)
                return ResultService.Fail<CityDTO>("Cidade não encontrado!");

            return ResultService.Ok<CityDTO>(_mapper.Map<CityDTO>(state));
        }

        public async Task<ResultService> UpdateAsync(CityDTO cityDTO)
        {
            if (cityDTO == null)
                return ResultService.Fail<CityDTO>("Objeto deve ser informado!");

            var validation = new CityDTOValidation().Validate(cityDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<CityDTO>("Problemas na validação dos campos!", validation);

            var city = await _cityRepository.GetById(cityDTO.Id);
            if (city == null)
                return ResultService.Fail<CityDTO>("Cidade não encontrado!");

            city = _mapper.Map<CityDTO, City>(cityDTO, city);

            _cityRepository.UpdateAsync(city);

            return ResultService.Ok($"Cidade {city.CityName} atualizado com sucesso!");
        }
    }
}
