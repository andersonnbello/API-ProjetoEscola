using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class StudentSerieService : IStudentSerieService
    {
        private readonly IStudentSerieRepository _studentSerieRepository;
        private readonly IStudentsRepository _studentRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IMapper _mapper;

        public StudentSerieService(
            IStudentSerieRepository studentSerieRepository, 
            IMapper mapper, 
            IStudentsRepository studentRepository, 
            ISerieRepository serieRepository)
        {
            _studentSerieRepository = studentSerieRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _serieRepository = serieRepository;
        }

        public ResultService<StudentSerieDTO> CreateAsync(StudentSerieDTO studentSerieDTO)
        {
            if (studentSerieDTO == null)
                return ResultService.Fail<StudentSerieDTO>("Objeto deve ser informado!");

            var validation = new StudentSerieDTOValidation().Validate(studentSerieDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StudentSerieDTO>("Problemas nas validações dos campos!", validation);

            var studentSerieEntity = _mapper.Map<StudentSerie>(studentSerieDTO);

            _studentSerieRepository.CreateAsync(studentSerieEntity);

            return ResultService.Ok<StudentSerieDTO>(_mapper.Map<StudentSerieDTO>(studentSerieEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentSerieRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _studentSerieRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<StudentSerieDTO>>> GetAllAsync()
        {
            var list = await _studentSerieRepository.GetAllAsync();
            if (list == null)
                return ResultService.Fail<IEnumerable<StudentSerieDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<StudentSerieDTO>>(_mapper.Map<IEnumerable<StudentSerieDTO>>(list));
        }

        public async Task<ResultService<StudentSerieDTO>> GetByStudentIdAsync(int id)
        {
            var list = await _studentSerieRepository.GetByStudentIdAsync(id);
            if (list == null)
                return ResultService.Fail<StudentSerieDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<StudentSerieDTO>(_mapper.Map<StudentSerieDTO>(list));
        }

        public async Task<ResultService<StudentSerieDTO>> GetByIdAsync(int id)
        {
            var response = await _studentSerieRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<StudentSerieDTO>("Registro não encontrado!");

            return ResultService.Ok<StudentSerieDTO>(_mapper.Map<StudentSerieDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(StudentSerieDTO studentSerieDTO)
        {

            if (studentSerieDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new StudentSerieDTOValidation().Validate(studentSerieDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _studentSerieRepository.GetByIdAsync(studentSerieDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var serie = await _serieRepository.GetById(studentSerieDTO.SerieId);
            if(serie == null)
            {
                return ResultService.Fail<StudentSerieDTO>("Não conseguimos atualizar, a série informada não existe!");
            }
            else
                  {
                response.Series.Name = serie.Name;
                response.Series.Id = serie.Id;
            }

            var student = await _studentRepository.GetByIdAsync(studentSerieDTO.StudentId);
            if (student == null)
            {
                return ResultService.Fail<StudentSerieDTO>("Não conseguimos atualizar, o aluno(a) informado não existe!");
            }
            else
            {
                response.Students.FullName = student.FullName;
                response.Students.Cpf = student.Cpf;
                response.Students.Age = student.Age;
                response.Students.BirthDate = student.BirthDate;
                response.Students.Rg = student.Rg;
                response.Students.isActive = student.isActive;
                response.Students.UpdatAt = student.UpdatAt;
                response.Students.CreatAt = student.CreatAt;
                response.Students.Id = student.Id;
            }

            response = _mapper.Map<StudentSerieDTO, StudentSerie>(studentSerieDTO, response);

            _studentSerieRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }
    }
}
