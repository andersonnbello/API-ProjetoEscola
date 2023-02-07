using AutoMapper;
using Correios;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Data.Repositories;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _studentsRepository;
        private readonly IDisciplinaRepository _subjectRepository;
        private readonly IAlunoDisciplinaRepository _studentsSubjectsRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IAlunoEnderecoRepository _alunoEnderecoRepository;
        private readonly IMapper _mapper;

        public AlunoService(
            IAlunoRepository studentsRepository,
            IMapper mapper,
            IDisciplinaRepository subjectRepository,
            IAlunoDisciplinaRepository studentsSubjectsRepository,
            ISerieRepository serieRepository,
            IEnderecoRepository enderecoRepository,
            IEstadoRepository estadoRepository,
            ICidadeRepository cidadeRepository,
            IAlunoEnderecoRepository alunoEnderecoRepository)
        {
            _studentsRepository = studentsRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _studentsSubjectsRepository = studentsSubjectsRepository;
            _serieRepository = serieRepository;
            _enderecoRepository = enderecoRepository;
            _estadoRepository = estadoRepository;
            _cidadeRepository = cidadeRepository;
            _alunoEnderecoRepository = alunoEnderecoRepository;
        }

        public async Task<ResultService<AlunoDTO>> CreateAsync(AlunoDTO studentsDTO)
        {
            #region Validações
            if (studentsDTO == null)
                return ResultService.Fail<AlunoDTO>("Objeto deve ser informado!");

            var validation = new StudentsDTOValidation().Validate(studentsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AlunoDTO>("Problema na validação dos campos!", validation);

            var cpfEncontrado = await _studentsRepository.GetByCPFAsync(studentsDTO.Cpf);
            if (cpfEncontrado != null)
                return ResultService.Fail<AlunoDTO>("Cpf já cadastrado, tente novamente mais tarde!");

            var rgEncontrado = await _studentsRepository.GetByRGAsync(studentsDTO.Rg);
            if (rgEncontrado != null)
                return ResultService.Fail<AlunoDTO>("Rg já cadastrado, tente novamente mais tarde!");

            var studentsEntity = _mapper.Map<Aluno>(studentsDTO);

            if (studentsDTO.DataNascimento.Date.Year > 2007)
            {
                return ResultService.Fail<AlunoDTO>("Aluno menor de 16 anos não pode ser matriculado nessa escola!");
            }

            #endregion

            int anoAtual = DateTime.Now.Year;
            int anoNascimento = studentsDTO.DataNascimento.Date.Year;

            var idadeAluno = anoAtual - anoNascimento;
            studentsEntity.Idade = idadeAluno;

            studentsEntity.CreatAt = DateTime.Now;
            studentsEntity.isAtivo = true;

            _studentsRepository.CreateAsync(studentsEntity);

            var subjects = await _subjectRepository.GetAllAsync();

            foreach (var subject in subjects)
            {
                AlunoDisciplina studentSubject = new AlunoDisciplina();

                studentSubject.AlunoId = studentsEntity.Id;
                studentSubject.DisciplinaId = subject.Id;

                _studentsSubjectsRepository.CreateAsync(studentSubject);
            }

            CorreiosApi correiosApi = new CorreiosApi();
            var retornoCep = correiosApi.consultaCEP(studentsDTO.Cep);

            var endereco = await _enderecoRepository.GetByName(retornoCep.end);
            var city = await _cidadeRepository.GetByNameAsync(retornoCep.cidade);
            var estado = await _estadoRepository.GetByNameAsync(retornoCep.uf);

            AlunoEndereco alunoEndereco = new AlunoEndereco();

            if (endereco.NomeEndereco.ToLower() == retornoCep.end.ToLower())
            {
                alunoEndereco.EnderecoId = endereco.Id;
            }
            else
            {
                Endereco enderecoET = new Endereco();
                enderecoET.NomeEndereco = retornoCep.end;
                _enderecoRepository.CreateAsync(enderecoET);
            }
            if (city.NomeCidade.ToLower() == retornoCep.cidade.ToLower())
            {
                alunoEndereco.CidadeId = city.Id;
            }
            else
            {
                Cidade cidade = new Cidade();
                cidade.NomeCidade = retornoCep.cidade;
                _cidadeRepository.CreateAsync(cidade);
            }
            if (estado.NomeEstado.ToLower() == retornoCep.uf.ToLower())
            {
                alunoEndereco.EstadoId = estado.Id;
            }
            else
            {
                Estado estadoET = new Estado();
                estadoET.NomeEstado = retornoCep.uf;
                var stateCreate = _estadoRepository.CreateAsync(estadoET);
            }

            alunoEndereco.AlunoId = studentsEntity.Id;

            _alunoEnderecoRepository.CreateAsync(alunoEndereco);


            return ResultService.Ok<AlunoDTO>(_mapper.Map<AlunoDTO>(studentsEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Aluno não encontrado!");

            await _studentsRepository.DeleteAsync(response);

            return ResultService.Ok("Aluno deletado com sucesso!");
        }

        public async Task<ResultService<IEnumerable<AlunoDTO>>> GetAllAsync()
        {
            var students = await _studentsRepository.GetAllAsync();
            if (students == null)
                return ResultService.Fail<IEnumerable<AlunoDTO>>("Nenhum registo encontrado!");

            return ResultService.Ok<IEnumerable<AlunoDTO>>(_mapper.Map<IEnumerable<AlunoDTO>>(students));
        }

        public async Task<ResultService<AlunoDTO>> GetByCPFAsync(string cpf)
        {
            var response = await _studentsRepository.GetByCPFAsync(cpf);
            if (response == null)
                return ResultService.Fail<AlunoDTO>("Aluno não encontrado!");

            return ResultService.Ok<AlunoDTO>(_mapper.Map<AlunoDTO>(response));
        }

        public async Task<ResultService<AlunoDTO>> GetByIdAsync(int id)
        {
            var response = await _studentsRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<AlunoDTO>("Aluno não encontrado!");

            return ResultService.Ok<AlunoDTO>(_mapper.Map<AlunoDTO>(response));
        }

        public async Task<ResultService<AlunoDTO>> GetByRGAsync(string rg)
        {
            var response = await _studentsRepository.GetByRGAsync(rg);
            if (response == null)
                return ResultService.Fail<AlunoDTO>("Aluno não encontrado!");

            return ResultService.Ok<AlunoDTO>(_mapper.Map<AlunoDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(AlunoDTO studentsDTO)
        {
            if (studentsDTO == null)
                return ResultService.Fail<AlunoDTO>("Objeto deve ser informado!");

            var validation = new StudentsDTOValidation().Validate(studentsDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AlunoDTO>("Problemas na validação dos campos!", validation);

            var students = await _studentsRepository.GetByIdAsync(studentsDTO.Id);
            if (students == null)
                return ResultService.Fail<AlunoDTO>("Aluno não encontrado!");

            studentsDTO.CreatAt = students.CreatAt;

            students = _mapper.Map<AlunoDTO, Aluno>(studentsDTO, students);

            students.UpdatAt = DateTime.Now;

            _studentsRepository.UpdateAsync(students);

            return ResultService.Ok("Aluno atualizado com sucesso!");
        }
    }
}
