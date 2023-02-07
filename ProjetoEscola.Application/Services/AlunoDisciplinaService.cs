using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Data.Repositories;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class AlunoDisciplinaService : IAlunoDisciplinaService
    {
        private readonly IAlunoDisciplinaRepository _studentsSubjectsRepository;
        private readonly IDisciplinaRepository _subjectRepository;
        private readonly IAlunoRepository _studentsRepository;
        private readonly IMapper _mapper;

        public AlunoDisciplinaService(
            IAlunoDisciplinaRepository studentsSubjectsRepository, 
            IMapper mapper, 
            IDisciplinaRepository subjectRepository, 
            IAlunoRepository studentsRepository)
        {
            _studentsSubjectsRepository = studentsSubjectsRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _studentsRepository = studentsRepository;
        }

        public ResultService<AlunoDisciplinaDTO> CreateAsync(AlunoDisciplinaDTO studentsSubjectsDTO)
        {
            if (studentsSubjectsDTO == null)
                return ResultService.Fail<AlunoDisciplinaDTO>("Objeto deve ser informado!");

            var validation = new StudentsSubjectsDTOValidation().Validate(studentsSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AlunoDisciplinaDTO>("Problemas nas validações dos campos!", validation);

            var studentSubjectEntity = _mapper.Map<AlunoDisciplina>(studentsSubjectsDTO);

            _studentsSubjectsRepository.CreateAsync(studentSubjectEntity);

            return ResultService.Ok<AlunoDisciplinaDTO>(_mapper.Map<AlunoDisciplinaDTO>(studentSubjectEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentsSubjectsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _studentsSubjectsRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<AlunoDisciplinaDTO>>> GetAllAsync()
        {
            var list = await _studentsSubjectsRepository.GetAllAsync();
            if (list == null)
                return ResultService.Fail<IEnumerable<AlunoDisciplinaDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<AlunoDisciplinaDTO>>(_mapper.Map<IEnumerable<AlunoDisciplinaDTO>>(list));
        }

        public async Task<ResultService<IEnumerable<AlunoDisciplinaDTO>>> GetAllAsync(int id)
        {
            var list = await _studentsSubjectsRepository.GetAllAsync(id);
            if (list == null)
                return ResultService.Fail<IEnumerable<AlunoDisciplinaDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<AlunoDisciplinaDTO>>(_mapper.Map<IEnumerable<AlunoDisciplinaDTO>>(list));
        }

        public async Task<ResultService<AlunoDisciplinaDTO>> GetByIdAsync(int id)
        {
            var response = await _studentsSubjectsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<AlunoDisciplinaDTO>("Registro não encontrado!");

            return ResultService.Ok<AlunoDisciplinaDTO>(_mapper.Map<AlunoDisciplinaDTO>(response));
        }

        public async Task<ResultService<AlunoDisciplinaDTO>> GetByStudentIdAsync(int id)
        {
            var list = await _studentsSubjectsRepository.GetByStudentIdAsync(id);
            if (list == null)
                return ResultService.Fail<AlunoDisciplinaDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<AlunoDisciplinaDTO>(_mapper.Map<AlunoDisciplinaDTO>(list));
        }

        public async Task<ResultService<AlunoDisciplinaDTO>> GetBySubjectIdAsync(int id)
        {
            var list = await _studentsSubjectsRepository.GetBySubjectIdAsync(id);
            if (list == null)
                return ResultService.Fail<AlunoDisciplinaDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<AlunoDisciplinaDTO>(_mapper.Map<AlunoDisciplinaDTO>(list));
        }

        public async Task<ResultService> UpdateAsync(AlunoDisciplinaDTO studentsSubjectsDTO)
        {

            if (studentsSubjectsDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new StudentsSubjectsDTOValidation().Validate(studentsSubjectsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _studentsSubjectsRepository.GetByIdAsync(studentsSubjectsDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var subject = await _subjectRepository.GetById(studentsSubjectsDTO.DisciplinaId);
            if(subject == null)
            {
                return ResultService.Fail<AlunoDisciplinaDTO>("Não conseguimos atualizar, a máteria informada não existe!");
            } 
            else
            {
                response.Disciplina.Id = subject.Id;
                response.Disciplina.NomeDisciplina = subject.NomeDisciplina;
            }

            var student = await _studentsRepository.GetByIdAsync(studentsSubjectsDTO.AlunoId);
            if (subject == null)
            {
                return ResultService.Fail<AlunoDisciplinaDTO>("Não conseguimos atualizar, o aluno(a) informado não existe!");
            }
            else
            {
                response.Aluno.Id = student.Id;
                response.Aluno.NomeCompleto = student.NomeCompleto;
                response.Aluno.Idade = student.Idade;
                response.Aluno.DataNascimento = student.DataNascimento;
                response.Aluno.Cpf = student.Cpf;
                response.Aluno.Rg = student.Rg;
                response.Aluno.isAtivo = student.isAtivo;
                response.Aluno.UpdatAt = student.UpdatAt;
                response.Aluno.CreatAt = student.CreatAt;
            }

            response = _mapper.Map<AlunoDisciplinaDTO, AlunoDisciplina>(studentsSubjectsDTO, response);

            _studentsSubjectsRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }
    }
}
