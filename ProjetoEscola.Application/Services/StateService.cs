using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class StateService : IStateService
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;

        public StateService(IMapper mapper, IStateRepository stateRepository)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }

        public ResultService<StateDTO> CreateAsync(StateDTO stateDTO)
        {
            if (stateDTO == null)
                return ResultService.Fail<StateDTO>("Objeto deve ser informado!");

            var validation = new StateDTOValidation().Validate(stateDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StateDTO>("Problemas na validação dos campos!", validation);

            var stateEntity = _mapper.Map<State>(stateDTO);

            _stateRepository.CreateAsync(stateEntity);

            return ResultService.Ok<StateDTO>(_mapper.Map<StateDTO>(stateEntity));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var state = await _stateRepository.GetById(id);
            if (state == null)
                return ResultService.Fail("Estado não encontrado!");

            await _stateRepository.DeleteAsync(state);

            return ResultService.Ok($"Estado {state.StateName} excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<StateDTO>>> GetAllAsync()
        {
            var listState = await _stateRepository.GetAllAsync();
            if (listState == null)
                return ResultService.Fail<IEnumerable<StateDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<IEnumerable<StateDTO>>(_mapper.Map<IEnumerable<StateDTO>>(listState));
        }

        public async Task<ResultService<StateDTO>> GetById(int id)
        {
            var state = await _stateRepository.GetById(id);
            if (state == null)
                return ResultService.Fail<StateDTO>("Estado não encontrado!");

            return ResultService.Ok<StateDTO>(_mapper.Map<StateDTO>(state));
        }

        public async Task<ResultService<StateDTO>> GetByNameAsync(string stateName)
        {
            var state = await _stateRepository.GetByNameAsync(stateName);
            if (state == null)
                return ResultService.Fail<StateDTO>("Estado não encontrado!");

            return ResultService.Ok<StateDTO>(_mapper.Map<StateDTO>(state));
        }

        public async Task<ResultService> UpdateAsync(StateDTO stateDTO)
        {
            if (stateDTO == null)
                return ResultService.Fail<StateDTO>("Objeto deve ser informado!");

            var validation = new StateDTOValidation().Validate(stateDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StateDTO>("Problemas na validação dos campos!", validation);

            var state = await _stateRepository.GetById(stateDTO.Id);
            if (state == null)
                return ResultService.Fail<StateDTO>("Estado não encontrado!");

            state = _mapper.Map<StateDTO, State>(stateDTO, state);

            _stateRepository.UpdateAsync(state);

            return ResultService.Ok($"Estado {state.StateName} atualizado com sucesso!");
        }
    }
}
