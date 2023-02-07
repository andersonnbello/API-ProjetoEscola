using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _subjectRepository;
        private readonly IMapper _mapper;

        public DisciplinaService(IDisciplinaRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public ResultService<DisciplinaDTO> CreateAsync(DisciplinaDTO subjectsDTO)
        {
            if (subjectsDTO == null)
                return ResultService.Fail<DisciplinaDTO>("Objeto deve ser informado!");

            var validation = new SubjectsDTOValidation().Validate(subjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<DisciplinaDTO>("Problema na validação dos campos!", validation);

            var subjectEntity = _mapper.Map<Disciplina>(subjectsDTO);

            _subjectRepository.CreateAsync(subjectEntity);

            return ResultService.Ok<DisciplinaDTO>(_mapper.Map<DisciplinaDTO>(subjectEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            if (subject == null)
                return ResultService.Fail("Disciplina não encontrada!");

            await _subjectRepository.DeleteAsync(subject);

            return ResultService.Ok("Disciplina apagada com sucesso!");
        }

        public async Task<ResultService<IEnumerable<DisciplinaDTO>>> GetAllAsync()
        {
            var listSubject = await _subjectRepository.GetAllAsync();
            if (listSubject == null)
                return ResultService.Fail<IEnumerable<DisciplinaDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<DisciplinaDTO>>(_mapper.Map<IEnumerable<DisciplinaDTO>>(listSubject));
        }

        public async Task<ResultService<DisciplinaDTO>> GetByIdAsync(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            if (subject == null)
                return ResultService.Fail<DisciplinaDTO>("Disciplina não encontrada!");

            return ResultService.Ok<DisciplinaDTO>(_mapper.Map<DisciplinaDTO>(subject));
        }

        public async Task<ResultService> UpdateAsync(DisciplinaDTO subjectsDTO)
        {
            if (subjectsDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new SubjectsDTOValidation().Validate(subjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema na validação dos campos!", validation);

            var subjectEntity = await _subjectRepository.GetById(subjectsDTO.Id);
            if (subjectEntity == null)
                return ResultService.Fail("Disciplina não encontrada!");

            subjectEntity = _mapper.Map<DisciplinaDTO, Disciplina>(subjectsDTO, subjectEntity);

            _subjectRepository.UpdateAsync(subjectEntity);

            return ResultService.Ok("Disiciplina atualizada com sucesso!");
        }
    }
}
