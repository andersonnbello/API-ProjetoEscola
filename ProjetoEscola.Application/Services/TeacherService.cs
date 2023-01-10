using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public ResultService<TeachersDTO> CreateAsync(TeachersDTO teachersDTO)
        {
            if (teachersDTO == null)
                return ResultService.Fail<TeachersDTO>("Objeto deve ser informado!");

            var validation = new TeachersDTOValidation().Validate(teachersDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<TeachersDTO>("Problema na validação dos campos!", validation);

            var teacherEntity = _mapper.Map<Teacher>(teachersDTO);

            teacherEntity.CreatAt = DateTime.Now;

            teacherEntity.UpdatAt = null;

            _teacherRepository.CreateAsync(teacherEntity);

            return ResultService.Ok<TeachersDTO>(_mapper.Map<TeachersDTO>(teacherEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
                return ResultService.Fail("Professor não encontrado!");

            await _teacherRepository.DeleteAync(teacher);

            return ResultService.Ok($"Professor {teacher.FullName} apagado com sucesso!");
        }

        public async Task<ResultService<List<TeachersDTO>>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            if (teachers == null)
                return ResultService.Fail<List<TeachersDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<List<TeachersDTO>>(_mapper.Map<List<TeachersDTO>>(teachers));
        }

        public async Task<ResultService<TeachersDTO>> GetByIdAsync(int id)
        {
            var teahcer = await _teacherRepository.GetByIdAsync(id);
            if (teahcer == null)
                return ResultService.Fail<TeachersDTO>("Professor não encontrado!");

            return ResultService.Ok<TeachersDTO>(_mapper.Map<TeachersDTO>(teahcer));
        }

        public async Task<ResultService> UpdateAsync(TeachersDTO teachersDTO)
        {
            if (teachersDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new TeachersDTOValidation().Validate(teachersDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema na validação dos campos!", validation);

            var teacher = await _teacherRepository.GetByIdAsync(teachersDTO.Id);
            if (teacher == null)
                return ResultService.Fail("Professor não encontrado!");

            teacher = _mapper.Map<TeachersDTO, Teacher>(teachersDTO, teacher);

            teacher.UpdatAt = DateTime.Now;

            _teacherRepository.UpdateAsync(teacher);

            return ResultService.Ok($"Professor {teacher.FullName} atualizado com sucesso!");
        }
    }
}
