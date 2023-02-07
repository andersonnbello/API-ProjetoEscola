using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _stateRepository;

        public EstadoService(IMapper mapper, IEstadoRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public ResultService<EstadoDTO> CreateAsync(EstadoDTO stateDTO)
        {
            if (stateDTO == null)
                return ResultService.Fail<EstadoDTO>("Objeto deve ser informado!");

            var validation = new StateDTOValidation().Validate(stateDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<EstadoDTO>("Problemas na validação dos campos!", validation);

            var stateEntity = _mapper.Map<Estado>(stateDTO);

            _stateRepository.CreateAsync(stateEntity);

            return ResultService.Ok<EstadoDTO>(_mapper.Map<EstadoDTO>(stateEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var state = await _stateRepository.GetById(id);
            if (state == null)
                return ResultService.Fail("Estado não encontrado!");

            await _stateRepository.DeleteAsync(state);

            return ResultService.Ok($"Estado {state.NomeEstado} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<EstadoDTO>>> GetAllAsync()
        {
            var listState = await _stateRepository.GetAllAsync();
            if (listState == null)
                return ResultService.Fail<IEnumerable<EstadoDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<EstadoDTO>>(_mapper.Map<IEnumerable<EstadoDTO>>(listState));
        }

        public async Task<ResultService<EstadoDTO>> GetById(int id)
        {
            var state = await _stateRepository.GetById(id);
            if (state == null)
                return ResultService.Fail<EstadoDTO>("Estado não encontrado!");

            return ResultService.Ok<EstadoDTO>(_mapper.Map<EstadoDTO>(state));
        }

        public async Task<ResultService<EstadoDTO>> GetByNameAsync(string stateName)
        {
            var state = await _stateRepository.GetByNameAsync(stateName);
            if (state == null)
                return ResultService.Fail<EstadoDTO>("Estado não encontrado!");

            return ResultService.Ok<EstadoDTO>(_mapper.Map<EstadoDTO>(state));
        }

        public async Task<ResultService> UpdateAsync(EstadoDTO stateDTO)
        {
            if (stateDTO == null)
                return ResultService.Fail<EstadoDTO>("Objeto deve ser informado!");

            var validation = new StateDTOValidation().Validate(stateDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<EstadoDTO>("Problemas na validação dos campos!", validation);

            var state = await _stateRepository.GetById(stateDTO.Id);
            if (state == null)
                return ResultService.Fail<EstadoDTO>("Estado não encontrado!");

            state = _mapper.Map<EstadoDTO, Estado>(stateDTO, state);

            _stateRepository.UpdateAsync(state);

            return ResultService.Ok($"Estado {state.NomeEstado} atualizado com sucesso!");
        }
    }
}
