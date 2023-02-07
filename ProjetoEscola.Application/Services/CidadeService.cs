using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _cityRepository;

        public CidadeService(IMapper mapper, ICidadeRepository cityRepository)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public ResultService<CidadeDTO> CreateAsync(CidadeDTO cityDTO)
        {
            if (cityDTO == null)
                return ResultService.Fail<CidadeDTO>("Objeto deve ser informado!");

            var validation = new CityDTOValidation().Validate(cityDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<CidadeDTO>("Problemas na validação dos campos!", validation);

            var cityEntity = _mapper.Map<Cidade>(cityDTO);

            _cityRepository.CreateAsync(cityEntity);

            return ResultService.Ok<CidadeDTO>(_mapper.Map<CidadeDTO>(cityEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var city = await _cityRepository.GetById(id);
            if (city == null)
                return ResultService.Fail("Cidade não encontrado!");

            await _cityRepository.DeleteAsync(city);

            return ResultService.Ok($"Cidade {city.NomeCidade} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<CidadeDTO>>> GetAllAsync()
        {
            var listCities = await _cityRepository.GetAllAsync();
            if (listCities == null)
                return ResultService.Fail<IEnumerable<CidadeDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<CidadeDTO>>(_mapper.Map<IEnumerable<CidadeDTO>>(listCities));
        }

        public async Task<ResultService<CidadeDTO>> GetById(int id)
        {
            var state = await _cityRepository.GetById(id);
            if (state == null)
                return ResultService.Fail<CidadeDTO>("Cidade não encontrado!");

            return ResultService.Ok<CidadeDTO>(_mapper.Map<CidadeDTO>(state));
        }

        public async Task<ResultService<CidadeDTO>> GetByNameAsync(string cityName)
        {
            var state = await _cityRepository.GetByNameAsync(cityName);
            if (state == null)
                return ResultService.Fail<CidadeDTO>("Cidade não encontrado!");

            return ResultService.Ok<CidadeDTO>(_mapper.Map<CidadeDTO>(state));
        }

        public async Task<ResultService> UpdateAsync(CidadeDTO cityDTO)
        {
            if (cityDTO == null)
                return ResultService.Fail<CidadeDTO>("Objeto deve ser informado!");

            var validation = new CityDTOValidation().Validate(cityDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<CidadeDTO>("Problemas na validação dos campos!", validation);

            var city = await _cityRepository.GetById(cityDTO.Id);
            if (city == null)
                return ResultService.Fail<CidadeDTO>("Cidade não encontrado!");

            city = _mapper.Map<CidadeDTO, Cidade>(cityDTO, city);

            _cityRepository.UpdateAsync(city);

            return ResultService.Ok($"Cidade {city.NomeCidade} atualizado com sucesso!");
        }
    }
}
