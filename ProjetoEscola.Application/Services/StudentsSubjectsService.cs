using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Data.Repositories;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class StudentsSubjectsService : IStudentsSubjectsService
    {
        private readonly IStudentsSubjectsRepository _studentsSubjectsRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IMapper _mapper;

        public StudentsSubjectsService(
            IStudentsSubjectsRepository studentsSubjectsRepository, 
            IMapper mapper, 
            ISubjectRepository subjectRepository, 
            IStudentsRepository studentsRepository)
        {
            _studentsSubjectsRepository = studentsSubjectsRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _studentsRepository = studentsRepository;
        }

        public ResultService<StudentsSubjectsDTO> CreateAsync(StudentsSubjectsDTO studentsSubjectsDTO)
        {
            if (studentsSubjectsDTO == null)
                return ResultService.Fail<StudentsSubjectsDTO>("Objeto deve ser informado!");

            var validation = new StudentsSubjectsDTOValidation().Validate(studentsSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StudentsSubjectsDTO>("Problemas nas validações dos campos!", validation);

            var studentSubjectEntity = _mapper.Map<StudentSubject>(studentsSubjectsDTO);

            _studentsSubjectsRepository.CreateAsync(studentSubjectEntity);

            return ResultService.Ok<StudentsSubjectsDTO>(_mapper.Map<StudentsSubjectsDTO>(studentSubjectEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentsSubjectsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _studentsSubjectsRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<StudentsSubjectsDTO>>> GetAllAsync()
        {
            var list = await _studentsSubjectsRepository.GetAllAsync();
            if (list == null)
                return ResultService.Fail<IEnumerable<StudentsSubjectsDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<StudentsSubjectsDTO>>(_mapper.Map<IEnumerable<StudentsSubjectsDTO>>(list));
        }

        public async Task<ResultService<IEnumerable<StudentsSubjectsDTO>>> GetAllAsync(int id)
        {
            var list = await _studentsSubjectsRepository.GetAllAsync(id);
            if (list == null)
                return ResultService.Fail<IEnumerable<StudentsSubjectsDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<StudentsSubjectsDTO>>(_mapper.Map<IEnumerable<StudentsSubjectsDTO>>(list));
        }

        public async Task<ResultService<StudentsSubjectsDTO>> GetByIdAsync(int id)
        {
            var response = await _studentsSubjectsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<StudentsSubjectsDTO>("Registro não encontrado!");

            return ResultService.Ok<StudentsSubjectsDTO>(_mapper.Map<StudentsSubjectsDTO>(response));
        }

        public async Task<ResultService<StudentsSubjectsDTO>> GetByStudentIdAsync(int id)
        {
            var list = await _studentsSubjectsRepository.GetByStudentIdAsync(id);
            if (list == null)
                return ResultService.Fail<StudentsSubjectsDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<StudentsSubjectsDTO>(_mapper.Map<StudentsSubjectsDTO>(list));
        }

        public async Task<ResultService<StudentsSubjectsDTO>> GetBySubjectIdAsync(int id)
        {
            var list = await _studentsSubjectsRepository.GetBySubjectIdAsync(id);
            if (list == null)
                return ResultService.Fail<StudentsSubjectsDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<StudentsSubjectsDTO>(_mapper.Map<StudentsSubjectsDTO>(list));
        }

        public async Task<ResultService> UpdateAsync(StudentsSubjectsDTO studentsSubjectsDTO)
        {

            if (studentsSubjectsDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new StudentsSubjectsDTOValidation().Validate(studentsSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _studentsSubjectsRepository.GetByIdAsync(studentsSubjectsDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var subject = await _subjectRepository.GetById(studentsSubjectsDTO.SubjectId);
            if(subject == null)
            {
                return ResultService.Fail<StudentsSubjectsDTO>("Não conseguimos atualizar, a máteria informada não existe!");
            } 
            else
            {
                response.Subjects.Id = subject.Id;
                response.Subjects.Name = subject.Name;
            }

            var student = await _studentsRepository.GetByIdAsync(studentsSubjectsDTO.StudentId);
            if (subject == null)
            {
                return ResultService.Fail<StudentsSubjectsDTO>("Não conseguimos atualizar, o aluno(a) informado não existe!");
            }
            else
            {
                response.Students.Id = student.Id;
                response.Students.FullName = student.FullName;
                response.Students.Age = student.Age;
                response.Students.BirthDate = student.BirthDate;
                response.Students.Cpf = student.Cpf;
                response.Students.Rg = student.Rg;
                response.Students.isActive = student.isActive;
                response.Students.UpdatAt = student.UpdatAt;
                response.Students.CreatAt = student.CreatAt;
            }

            response = _mapper.Map<StudentsSubjectsDTO, StudentSubject>(studentsSubjectsDTO, response);

            _studentsSubjectsRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }
    }
}
