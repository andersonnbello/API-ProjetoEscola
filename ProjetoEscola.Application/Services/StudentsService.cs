using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentsSubjectsRepository _studentsSubjectsRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IMapper _mapper;

        public StudentsService(
            IStudentsRepository studentsRepository, 
            IMapper mapper,    
            ISubjectRepository subjectRepository, 
            IStudentsSubjectsRepository studentsSubjectsRepository, 
            ISerieRepository serieRepository)
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _studentsSubjectsRepository = studentsSubjectsRepository;
            _serieRepository = serieRepository;
        }

        public async Task<ResultService<StudentsDTO>> CreateAsync(StudentsDTO studentsDTO)
        {
            if (studentsDTO == null)
                return ResultService.Fail<StudentsDTO>("Objeto deve ser informado!");

            var validation = new StudentsDTOValidation().Validate(studentsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StudentsDTO>("Problema na validação dos campos!", validation);

            var cpfEncontrado = await _studentsRepository.GetByCPFAsync(studentsDTO.Cpf);
            if (cpfEncontrado != null)
                return ResultService.Fail<StudentsDTO>("Cpf já cadastrado, tente novamente mais tarde!");

            var rgEncontrado = await _studentsRepository.GetByRGAsync(studentsDTO.Rg);
            if (rgEncontrado != null)
                return ResultService.Fail<StudentsDTO>("Rg já cadastrado, tente novamente mais tarde!");

            var studentsEntity = _mapper.Map<Student>(studentsDTO);

            if (studentsDTO.BirthDate.Date.Year > 2007)
            {
                return ResultService.Fail<StudentsDTO>("Aluno menor de 16 anos não pode ser matriculado nessa escola!");
            }

            int anoAtual = DateTime.Now.Year;
            int anoNascimento = studentsDTO.BirthDate.Date.Year;

            var idadeAluno = anoAtual - anoNascimento;
            studentsEntity.Age = idadeAluno;

            studentsEntity.CreatAt = DateTime.Now;
            studentsEntity.isActive = true;

            _studentsRepository.CreateAsync(studentsEntity);

            var subjects = await _subjectRepository.GetAllAsync();

            foreach (var subject in subjects)
            {
                StudentSubject studentSubject = new StudentSubject();

                studentSubject.StudentId = studentsEntity.Id;
                studentSubject.SubjectId = subject.Id;

                _studentsSubjectsRepository.CreateAsync(studentSubject);
            }

            return ResultService.Ok<StudentsDTO>(_mapper.Map<StudentsDTO>(studentsEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Aluno não encontrado!");

            await _studentsRepository.DeleteAsync(response);

            return ResultService.Ok("Aluno deletado com sucesso!");
        }

        public async Task<ResultService<IEnumerable<StudentsDTO>>> GetAllAsync()
        {
            var students = await _studentsRepository.GetAllAsync();
            if (students == null)
                return ResultService.Fail<IEnumerable<StudentsDTO>>("Nenhum registo encontrado!");

            return ResultService.Ok<IEnumerable<StudentsDTO>>(_mapper.Map<IEnumerable<StudentsDTO>>(students));
        }

        public async Task<ResultService<StudentsDTO>> GetByCPFAsync(string cpf)
        {
            var response = await _studentsRepository.GetByCPFAsync(cpf);
            if (response == null)
                return ResultService.Fail<StudentsDTO>("Aluno não encontrado!");

            return ResultService.Ok<StudentsDTO>(_mapper.Map<StudentsDTO>(response));
        }

        public async Task<ResultService<StudentsDTO>> GetByIdAsync(int id)
        {
            var response = await _studentsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<StudentsDTO>("Aluno não encontrado!");

            return ResultService.Ok<StudentsDTO>(_mapper.Map<StudentsDTO>(response));
        }

        public async Task<ResultService<StudentsDTO>> GetByRGAsync(string rg)
        {
            var response = await _studentsRepository.GetByRGAsync(rg);
            if (response == null)
                return ResultService.Fail<StudentsDTO>("Aluno não encontrado!");

            return ResultService.Ok<StudentsDTO>(_mapper.Map<StudentsDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(StudentsDTO studentsDTO)
        {
            if (studentsDTO == null)
                return ResultService.Fail<StudentsDTO>("Objeto deve ser informado!");

            var validation = new StudentsDTOValidation().Validate(studentsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StudentsDTO>("Problemas na validação dos campos!", validation);

            var students = await _studentsRepository.GetByIdAsync(studentsDTO.Id);
            if (students == null)
                return ResultService.Fail<StudentsDTO>("Aluno não encontrado!");

            studentsDTO.CreatAt = students.CreatAt;

            students = _mapper.Map<StudentsDTO, Student>(studentsDTO, students);

            students.UpdatAt = DateTime.Now;

            _studentsRepository.UpdateAsync(students);

            return ResultService.Ok("Aluno atualizado com sucesso!");
        }
    }
}
