using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class ProfessorDisciplinaService : IProfessorDisciplinaService
    {
        private readonly IProfessorDisicplinaRepository _teacherSubjectRepository;
        private readonly IDisciplinaRepository _subjectRepository;
        private readonly IProfessorRepository _teacherRepository;
        private readonly IMapper _mapper;

        public ProfessorDisciplinaService(
            IProfessorDisicplinaRepository teacherSubjectRepository, 
            IMapper mapper, 
            IProfessorRepository teacherRepository, 
            IDisciplinaRepository subjectRepository)
        {
            _teacherSubjectRepository = teacherSubjectRepository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<ResultService<IEnumerable<ProfessorDisciplinaDTO>>> GetAllAsync()
        {
            var teahcersSubjects = await _teacherSubjectRepository.GetAllAsync();
            if (teahcersSubjects == null)
                return ResultService.Fail<IEnumerable<ProfessorDisciplinaDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<ProfessorDisciplinaDTO>>(_mapper.Map<IEnumerable<ProfessorDisciplinaDTO>>(teahcersSubjects));
        }

        public ResultService<ProfessorDisciplinaDTO> CreateAsync(ProfessorDisciplinaDTO teachersSubjectsDTO)
        {
            if (teachersSubjectsDTO == null)
                return ResultService.Fail<ProfessorDisciplinaDTO>("Objeto deve ser informado!");

            var validation = new TeachersSubjectsDTOValidation().Validate(teachersSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<ProfessorDisciplinaDTO>("Problemas nas validações dos campos!", validation);

            var teacherSubjectEntity = _mapper.Map<ProfessorDisciplina>(teachersSubjectsDTO);

            _teacherSubjectRepository.CreateAsync(teacherSubjectEntity);

            return ResultService.Ok<ProfessorDisciplinaDTO>(_mapper.Map<ProfessorDisciplinaDTO>(teacherSubjectEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _teacherSubjectRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<ProfessorDisciplinaDTO>> GetByIdAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<ProfessorDisciplinaDTO>("Registro não encontrado!");

            return ResultService.Ok<ProfessorDisciplinaDTO>(_mapper.Map<ProfessorDisciplinaDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(ProfessorDisciplinaDTO teachersSubjectsDTO)
        {

            if (teachersSubjectsDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new TeachersSubjectsDTOValidation().Validate(teachersSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _teacherSubjectRepository.GetByIdAsync(teachersSubjectsDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var teacher = await _teacherRepository.GetByIdAsync(teachersSubjectsDTO.ProfessorId);
            if(teacher == null)
            {
                return ResultService.Fail<ProfessorDTO>("Não conseguimos atualizar, pois o professor(a) informado não existe!");
            }
            else
            {
                response.Professor.Id = teacher.Id;
                response.Professor.NomeCompleto = teacher.NomeCompleto;
                response.Professor.DataNascimento = teacher.DataNascimento;
                response.Professor.Cpf = teacher.Cpf;
                response.Professor.Rg = teacher.Rg;
                response.Professor.CreatAt = teacher.CreatAt;
                response.Professor.UpdatAt = teacher.UpdatAt;
            }

            var subjet = await _subjectRepository.GetById(teachersSubjectsDTO.DisciplinaId);
            if (subjet == null)
            {
                return ResultService.Fail<ProfessorDTO>("Não conseguimos atualizar, pois a máteria informada não existe!");
            }

            if(teacher == null && subjet == null)
            {
                return ResultService.Fail<ProfessorDTO>("Não conseguimos atualizar, pois a máteria e o professor(a) não existe!");
            }
            else
            {
                response.Disciplina.Id = subjet.Id;
                response.Disciplina.NomeDisciplina = subjet.NomeDisciplina;
            }

            response = _mapper.Map<ProfessorDisciplinaDTO, ProfessorDisciplina>(teachersSubjectsDTO, response);

            _teacherSubjectRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }

        public async Task<ResultService<ProfessorDisciplinaDTO>> GetBySubjectIdAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetBySubjectIdAsync(id);
            if (response == null)
                return ResultService.Fail<ProfessorDisciplinaDTO>("Registro não encontrado!");

            return ResultService.Ok<ProfessorDisciplinaDTO>(_mapper.Map<ProfessorDisciplinaDTO>(response));
        }

        public async Task<ResultService<ProfessorDisciplinaDTO>> GetByTeacherIdAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetByTeacherIdAsync(id);
            if (response == null)
                return ResultService.Fail<ProfessorDisciplinaDTO>("Registro não encontrado!");

            return ResultService.Ok<ProfessorDisciplinaDTO>(_mapper.Map<ProfessorDisciplinaDTO>(response));
        }
    }
}
