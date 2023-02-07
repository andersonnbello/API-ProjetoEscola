using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class AlunoSerieService : IAlunoSerieService
    {
        private readonly IAlunoSerieRepository _studentSerieRepository;
        private readonly IAlunoRepository _studentRepository;
        private readonly ISerieRepository _serieRepository;
        private readonly IMapper _mapper;

        public AlunoSerieService(
            IAlunoSerieRepository studentSerieRepository, 
            IMapper mapper, 
            IAlunoRepository studentRepository, 
            ISerieRepository serieRepository)
        {
            _studentSerieRepository = studentSerieRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _serieRepository = serieRepository;
        }

        public ResultService<AlunoSerieDTO> CreateAsync(AlunoSerieDTO studentSerieDTO)
        {
            if (studentSerieDTO == null)
                return ResultService.Fail<AlunoSerieDTO>("Objeto deve ser informado!");

            var validation = new StudentSerieDTOValidation().Validate(studentSerieDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AlunoSerieDTO>("Problemas nas validações dos campos!", validation);

            var studentSerieEntity = _mapper.Map<AlunoSerie>(studentSerieDTO);

            _studentSerieRepository.CreateAsync(studentSerieEntity);

            return ResultService.Ok<AlunoSerieDTO>(_mapper.Map<AlunoSerieDTO>(studentSerieEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentSerieRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _studentSerieRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<IEnumerable<AlunoSerieDTO>>> GetAllAsync()
        {
            var list = await _studentSerieRepository.GetAllAsync();
            if (list == null)
                return ResultService.Fail<IEnumerable<AlunoSerieDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<IEnumerable<AlunoSerieDTO>>(_mapper.Map<IEnumerable<AlunoSerieDTO>>(list));
        }

        public async Task<ResultService<AlunoSerieDTO>> GetByStudentIdAsync(int id)
        {
            var list = await _studentSerieRepository.GetByStudentIdAsync(id);
            if (list == null)
                return ResultService.Fail<AlunoSerieDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<AlunoSerieDTO>(_mapper.Map<AlunoSerieDTO>(list));
        }

        public async Task<ResultService<AlunoSerieDTO>> GetByIdAsync(int id)
        {
            var response = await _studentSerieRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<AlunoSerieDTO>("Registro não encontrado!");

            return ResultService.Ok<AlunoSerieDTO>(_mapper.Map<AlunoSerieDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(AlunoSerieDTO studentSerieDTO)
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
                return ResultService.Fail<AlunoSerieDTO>("Não conseguimos atualizar, a série informada não existe!");
            }
            else
                  {
                response.Series.NomeSerie = serie.NomeSerie;
                response.Series.Id = serie.Id;
            }

            var student = await _studentRepository.GetByIdAsync(studentSerieDTO.AlunoId);
            if (student == null)
            {
                return ResultService.Fail<AlunoSerieDTO>("Não conseguimos atualizar, o aluno(a) informado não existe!");
            }
            else
            {
                response.Aluno.NomeCompleto = student.NomeCompleto;
                response.Aluno.Cpf = student.Cpf;
                response.Aluno.Idade = student.Idade;
                response.Aluno.DataNascimento = student.DataNascimento;
                response.Aluno.Rg = student.Rg;
                response.Aluno.isAtivo = student.isAtivo;
                response.Aluno.UpdatAt = student.UpdatAt;
                response.Aluno.CreatAt = student.CreatAt;
                response.Aluno.Id = student.Id;
            }

            response = _mapper.Map<AlunoSerieDTO, AlunoSerie>(studentSerieDTO, response);

            _studentSerieRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }
    }
}
