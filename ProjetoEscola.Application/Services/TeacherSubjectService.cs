using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class TeacherSubjectService : ITeacherSubjectService
    {
        private readonly ITeacherSubjectRepository _teacherSubjectRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherSubjectService(
            ITeacherSubjectRepository teacherSubjectRepository, 
            IMapper mapper, 
            ITeacherRepository teacherRepository, 
            ISubjectRepository subjectRepository)
        {
            _teacherSubjectRepository = teacherSubjectRepository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<ResultService<IEnumerable<TeachersSubjectsDTO>>> GetAllAsync()
        {
            var teahcersSubjects = await _teacherSubjectRepository.GetAllAsync();
            if (teahcersSubjects == null)
                return ResultService.Fail<IEnumerable<TeachersSubjectsDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<TeachersSubjectsDTO>>(_mapper.Map<IEnumerable<TeachersSubjectsDTO>>(teahcersSubjects));
        }

        public ResultService<TeachersSubjectsDTO> CreateAsync(TeachersSubjectsDTO teachersSubjectsDTO)
        {
            if (teachersSubjectsDTO == null)
                return ResultService.Fail<TeachersSubjectsDTO>("Objeto deve ser informado!");

            var validation = new TeachersSubjectsDTOValidation().Validate(teachersSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<TeachersSubjectsDTO>("Problemas nas validações dos campos!", validation);

            var teacherSubjectEntity = _mapper.Map<TeacherSubject>(teachersSubjectsDTO);

            _teacherSubjectRepository.CreateAsync(teacherSubjectEntity);

            return ResultService.Ok<TeachersSubjectsDTO>(_mapper.Map<TeachersSubjectsDTO>(teacherSubjectEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _teacherSubjectRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<TeachersSubjectsDTO>> GetByIdAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<TeachersSubjectsDTO>("Registro não encontrado!");

            return ResultService.Ok<TeachersSubjectsDTO>(_mapper.Map<TeachersSubjectsDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(TeachersSubjectsDTO teachersSubjectsDTO)
        {

            if (teachersSubjectsDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new TeachersSubjectsDTOValidation().Validate(teachersSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _teacherSubjectRepository.GetByIdAsync(teachersSubjectsDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var teacher = await _teacherRepository.GetByIdAsync(teachersSubjectsDTO.TeacherId);
            if(teacher == null)
            {
                return ResultService.Fail<TeachersDTO>("Não conseguimos atualizar, pois o professor(a) informado não existe!");
            }
            else
            {
                response.Teachers.Id = teacher.Id;
                response.Teachers.FullName = teacher.FullName;
                response.Teachers.BirthDate = teacher.BirthDate;
                response.Teachers.Cpf = teacher.Cpf;
                response.Teachers.Rg = teacher.Rg;
                response.Teachers.CreatAt = teacher.CreatAt;
                response.Teachers.UpdatAt = teacher.UpdatAt;
            }

            var subjet = await _subjectRepository.GetById(teachersSubjectsDTO.SubjectId);
            if (subjet == null)
            {
                return ResultService.Fail<TeachersDTO>("Não conseguimos atualizar, pois a máteria informada não existe!");
            }

            if(teacher == null && subjet == null)
            {
                return ResultService.Fail<TeachersDTO>("Não conseguimos atualizar, pois a máteria e o professor(a) não existe!");
            }
            else
            {
                response.Subjects.Id = subjet.Id;
                response.Subjects.Name = subjet.Name;
            }

            response = _mapper.Map<TeachersSubjectsDTO, TeacherSubject>(teachersSubjectsDTO, response);

            _teacherSubjectRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }

        public async Task<ResultService<TeachersSubjectsDTO>> GetBySubjectIdAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetBySubjectIdAsync(id);
            if (response == null)
                return ResultService.Fail<TeachersSubjectsDTO>("Registro não encontrado!");

            return ResultService.Ok<TeachersSubjectsDTO>(_mapper.Map<TeachersSubjectsDTO>(response));
        }

        public async Task<ResultService<TeachersSubjectsDTO>> GetByTeacherIdAsync(int id)
        {
            var response = await _teacherSubjectRepository.GetByTeacherIdAsync(id);
            if (response == null)
                return ResultService.Fail<TeachersSubjectsDTO>("Registro não encontrado!");

            return ResultService.Ok<TeachersSubjectsDTO>(_mapper.Map<TeachersSubjectsDTO>(response));
        }
    }
}
