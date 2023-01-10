using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public ResultService<SubjectsDTO> CreateAsync(SubjectsDTO subjectsDTO)
        {
            if (subjectsDTO == null)
                return ResultService.Fail<SubjectsDTO>("Objeto deve ser informado!");

            var validation = new SubjectsDTOValidation().Validate(subjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<SubjectsDTO>("Problema na validação dos campos!", validation);

            var subjectEntity = _mapper.Map<Subject>(subjectsDTO);

            _subjectRepository.CreateAsync(subjectEntity);

            return ResultService.Ok<SubjectsDTO>(_mapper.Map<SubjectsDTO>(subjectEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            if (subject == null)
                return ResultService.Fail("Disciplina não encontrada!");

            await _subjectRepository.DeleteAsync(subject);

            return ResultService.Ok("Disciplina apagada com sucesso!");
        }

        public async Task<ResultService<IEnumerable<SubjectsDTO>>> GetAllAsync()
        {
            var listSubject = await _subjectRepository.GetAllAsync();
            if (listSubject == null)
                return ResultService.Fail<IEnumerable<SubjectsDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<SubjectsDTO>>(_mapper.Map<IEnumerable<SubjectsDTO>>(listSubject));
        }

        public async Task<ResultService<SubjectsDTO>> GetByIdAsync(int id)
        {
            var subject = await _subjectRepository.GetById(id);
            if (subject == null)
                return ResultService.Fail<SubjectsDTO>("Disciplina não encontrada!");

            return ResultService.Ok<SubjectsDTO>(_mapper.Map<SubjectsDTO>(subject));
        }

        public async Task<ResultService> UpdateAsync(SubjectsDTO subjectsDTO)
        {
            if (subjectsDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new SubjectsDTOValidation().Validate(subjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema na validação dos campos!", validation);

            var subjectEntity = await _subjectRepository.GetById(subjectsDTO.Id);
            if (subjectEntity == null)
                return ResultService.Fail("Disciplina não encontrada!");

            subjectEntity = _mapper.Map<SubjectsDTO, Subject>(subjectsDTO, subjectEntity);

            _subjectRepository.UpdateAsync(subjectEntity);

            return ResultService.Ok("Disiciplina atualizada com sucesso!");
        }
    }
}
