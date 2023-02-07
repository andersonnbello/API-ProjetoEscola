using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class AlunoEnderecoService : IAlunoEnderecoService
    {
        private readonly IAlunoEnderecoRepository _studentsAddressRepository;
        private readonly IAlunoRepository _studentsRepository;
        private readonly ICidadeRepository _cityRepository;
        private readonly IEnderecoRepository _addressRepository;
        private readonly IEstadoRepository _stateRepository;
        private readonly IMapper _mapper;

        public AlunoEnderecoService(
            IAlunoEnderecoRepository studentsAddressRepository, 
            IMapper mapper, 
            IAlunoRepository studentsRepository, 
            ICidadeRepository cityRepository, 
            IEnderecoRepository addressRepository, 
            IEstadoRepository stateRepository)
        {
            _studentsAddressRepository = studentsAddressRepository;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _stateRepository = stateRepository;
        }

        public ResultService<AlunoEnderecoDTO> CreateAsync(AlunoEnderecoDTO studentsAddressDTO)
        {
            if (studentsAddressDTO == null)
                return ResultService.Fail<AlunoEnderecoDTO>("Objeto deve ser informado!");

            var validation = new StudentsAddressDTOValidation().Validate(studentsAddressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<AlunoEnderecoDTO>("Problemas nas validações dos campos!", validation);

            var studentAddresstEntity = _mapper.Map<AlunoEndereco>(studentsAddressDTO);

            _studentsAddressRepository.CreateAsync(studentAddresstEntity);

            return ResultService.Ok<AlunoEnderecoDTO>(_mapper.Map<AlunoEnderecoDTO>(studentAddresstEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentsAddressRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _studentsAddressRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<List<AlunoEnderecoDTO>>> GetAllAsync()
        {
            var list = await  _studentsAddressRepository.GetAllAsync();
            if (list == null)
                return ResultService.Fail<List<AlunoEnderecoDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<List<AlunoEnderecoDTO>>(_mapper.Map<List<AlunoEnderecoDTO>>(list));
        }

        public async Task<ResultService<AlunoEnderecoDTO>> GetByIdAsync(int id)
        {
            var response = await _studentsAddressRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<AlunoEnderecoDTO>("Registro não encontrado!");

            return ResultService.Ok<AlunoEnderecoDTO>(_mapper.Map<AlunoEnderecoDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(AlunoEnderecoDTO studentsAddressDTO)
        {

            if (studentsAddressDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new StudentsAddressDTOValidation().Validate(studentsAddressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _studentsAddressRepository.GetByIdAsync(studentsAddressDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var student = await _studentsRepository.GetByIdAsync(studentsAddressDTO.AlunoId);
            if(student == null)
            {
                return ResultService.Fail<AlunoEnderecoDTO>("Não conseguimos atualizar, o aluno(a) informado não existe!");
            }
            else
            {
                response.Aluno.Id = student.Id;
                response.Aluno.NomeCompleto = student.NomeCompleto;
                response.Aluno.DataNascimento = student.DataNascimento;
                response.Aluno.Cpf = student.Cpf;
                response.Aluno.Rg = student.Rg;
                response.Aluno.Idade = student.Idade;
                response.Aluno.isAtivo = student.isAtivo;
                response.Aluno.CreatAt = student.CreatAt;
                response.Aluno.UpdatAt = student.UpdatAt;
            }

            var city = await _cityRepository.GetById(studentsAddressDTO.CidadeId);
            if(city == null)
            {
                return ResultService.Fail<AlunoEnderecoDTO>("Não conseguimos atualizar, a cidade informada não existe!");
            }
            else
            {
                response.Cidade.Id = city.Id;
                response.Cidade.NomeCidade = city.NomeCidade;
            }

            var state = await _stateRepository.GetById(studentsAddressDTO.EstadoId);
            if (state == null)
            {
                return ResultService.Fail<AlunoEnderecoDTO>("Não conseguimos atualizar, o estado informada não existe!");
            }
            else
            {
                response.Estado.Id = state.Id;
                response.Estado.NomeEstado = state.NomeEstado;
            }

            var address = await _addressRepository.GetById(studentsAddressDTO.EnderecoId);
            if (address == null)
            {
                return ResultService.Fail<AlunoEnderecoDTO>("Não conseguimos atualizar, o endereço informado não existe!");
            }
            else
            {
                response.Endereco.Id = address.Id;
                response.Endereco.NomeEndereco = address.NomeEndereco;
            }

            response = _mapper.Map<AlunoEnderecoDTO, AlunoEndereco>(studentsAddressDTO, response);

            _studentsAddressRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }

        public async Task<ResultService<AlunoEnderecoDTO>> GetByStudentIdAsync(int id)
        {
            var list = await _studentsAddressRepository.GetByStudentIdAsync(id);
            if (list == null)
                return ResultService.Fail<AlunoEnderecoDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<AlunoEnderecoDTO>(_mapper.Map<AlunoEnderecoDTO>(list));
        }
    }
}
