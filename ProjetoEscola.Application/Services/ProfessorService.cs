using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _teacherRepository;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public ResultService<ProfessorDTO> CreateAsync(ProfessorDTO teachersDTO)
        {
            if (teachersDTO == null)
                return ResultService.Fail<ProfessorDTO>("Objeto deve ser informado!");

            var validation = new TeachersDTOValidation().Validate(teachersDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<ProfessorDTO>("Problema na validação dos campos!", validation);

            var teacherEntity = _mapper.Map<Professor>(teachersDTO);

            teacherEntity.CreatAt = DateTime.Now;

            teacherEntity.UpdatAt = null;

            _teacherRepository.CreateAsync(teacherEntity);

            return ResultService.Ok<ProfessorDTO>(_mapper.Map<ProfessorDTO>(teacherEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
                return ResultService.Fail("Professor não encontrado!");

            await _teacherRepository.DeleteAync(teacher);

            return ResultService.Ok($"Professor {teacher.NomeCompleto} apagado com sucesso!");
        }

        public async Task<ResultService<List<ProfessorDTO>>> GetAllAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            if (teachers == null)
                return ResultService.Fail<List<ProfessorDTO>>("Nenhum registro encontrado!");

            return ResultService.Ok<List<ProfessorDTO>>(_mapper.Map<List<ProfessorDTO>>(teachers));
        }

        public async Task<ResultService<ProfessorDTO>> GetByIdAsync(int id)
        {
            var teahcer = await _teacherRepository.GetByIdAsync(id);
            if (teahcer == null)
                return ResultService.Fail<ProfessorDTO>("Professor não encontrado!");

            return ResultService.Ok<ProfessorDTO>(_mapper.Map<ProfessorDTO>(teahcer));
        }

        public async Task<ResultService> UpdateAsync(ProfessorDTO teachersDTO)
        {
            if (teachersDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new TeachersDTOValidation().Validate(teachersDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problema na validação dos campos!", validation);

            var teacher = await _teacherRepository.GetByIdAsync(teachersDTO.Id);
            if (teacher == null)
                return ResultService.Fail("Professor não encontrado!");

            teacher = _mapper.Map<ProfessorDTO, Professor>(teachersDTO, teacher);

            teacher.UpdatAt = DateTime.Now;

            _teacherRepository.UpdateAsync(teacher);

            return ResultService.Ok($"Professor {teacher.NomeCompleto} atualizado com sucesso!");
        }
    }
}
