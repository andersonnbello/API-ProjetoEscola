using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _serieRepository;
        private IMapper _mapper;

        public SerieService(IMapper mapper, ISerieRepository serieRepository = null)
        {
            _mapper = mapper;
            _serieRepository = serieRepository;
        }

        public ResultService<SerieDTO> CreateAsync(SerieDTO serieDTO)
        {
            if (serieDTO == null)
                return ResultService.Fail<SerieDTO>("Objeto deve ser informado!");

            var validation = new SerieDTOValidation().Validate(serieDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<SerieDTO>("Problemas na validação dos campos!", validation);

            var serieEntity = _mapper.Map<Serie>(serieDTO);

            _serieRepository.CreateAsync(serieEntity);

            return ResultService.Ok<SerieDTO>(_mapper.Map<SerieDTO>(serieEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var serie = await _serieRepository.GetById(id);
            if (serie == null)
                return ResultService.Fail("Série não encontrado!");

            await _serieRepository.DeleteAsync(serie);

            return ResultService.Ok($"Serie {serie.NomeSerie} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<SerieDTO>>> GetAllAsync()
        {
            var listSeries = await _serieRepository.GetAllAsync();
            if (listSeries == null)
                return ResultService.Fail<IEnumerable<SerieDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<SerieDTO>>(_mapper.Map<IEnumerable<SerieDTO>>(listSeries));
        }

        public async Task<ResultService<SerieDTO>> GetById(int id)
        {
            var serie = await _serieRepository.GetById(id);
            if (serie == null)
                return ResultService.Fail<SerieDTO>("Série não encontrado!");

            return ResultService.Ok<SerieDTO>(_mapper.Map<SerieDTO>(serie));
        }

        public async Task<ResultService> UpdateAsync(SerieDTO serieDTO)
        {
            if (serieDTO == null)
                return ResultService.Fail<SerieDTO>("Objeto deve ser informado!");

            var validation = new SerieDTOValidation().Validate(serieDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<SerieDTO>("Problemas na validação dos campos!", validation);

            var serie = await _serieRepository.GetById(serieDTO.Id);
            if (serie == null)
                return ResultService.Fail<SerieDTO>("Série não encontrado!");

            serie = _mapper.Map<SerieDTO, Serie>(serieDTO, serie);

            _serieRepository.UpdateAsync(serie);

            return ResultService.Ok($"Série {serie.NomeSerie} atualizado com sucesso!");
        }
    }
}
