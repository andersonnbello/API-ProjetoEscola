using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Application.Services.Interfaces;
using ProjetoEscola.Application.Validations;
using ProjetoEscola.Domain.Entities;
using ProjetoEscola.Domain.Interface;

namespace ProjetoEscola.Application.Services
{
    public class StudentsAddressService : IStudentsAddressService
    {
        private readonly IStudentsAddressRepository _studentsAddressRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public StudentsAddressService(IStudentsAddressRepository studentsAddressRepository, IMapper mapper, IStudentsRepository studentsRepository, ICityRepository cityRepository, IAddressRepository addressRepository, IStateRepository stateRepository, ICountryRepository countryRepository)
        {
            _studentsAddressRepository = studentsAddressRepository;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
            _cityRepository = cityRepository;
            _addressRepository = addressRepository;
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
        }

        public ResultService<StudentsAddressDTO> CreateAsync(StudentsAddressDTO studentsAddressDTO)
        {
            if (studentsAddressDTO == null)
                return ResultService.Fail<StudentsAddressDTO>("Objeto deve ser informado!");

            var validation = new StudentsAddressDTOValidation().Validate(studentsAddressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<StudentsAddressDTO>("Problemas nas validações dos campos!", validation);

            var studentAddresstEntity = _mapper.Map<StudentAddress>(studentsAddressDTO);

            _studentsAddressRepository.CreateAsync(studentAddresstEntity);

            return ResultService.Ok<StudentsAddressDTO>(_mapper.Map<StudentsAddressDTO>(studentAddresstEntity));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var response = await _studentsAddressRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail("Nenhum registro foi encontrado!");

            await _studentsAddressRepository.DeleteAsync(response);

            return ResultService.Ok("Registro excluido com sucesso!");
        }

        public async Task<ResultService<List<StudentsAddressDTO>>> GetAllAsync()
        {
            var list = await  _studentsAddressRepository.GetAllAsync();
            if (list == null)
                return ResultService.Fail<List<StudentsAddressDTO>>("Nenhum registro foi encontrado!");

            return ResultService.Ok<List<StudentsAddressDTO>>(_mapper.Map<List<StudentsAddressDTO>>(list));
        }

        public async Task<ResultService<StudentsAddressDTO>> GetByIdAsync(int id)
        {
            var response = await _studentsAddressRepository.GetByIdAsync(id);
            if (response == null)
                return ResultService.Fail<StudentsAddressDTO>("Registro não encontrado!");

            return ResultService.Ok<StudentsAddressDTO>(_mapper.Map<StudentsAddressDTO>(response));
        }

        public async Task<ResultService> UpdateAsync(StudentsAddressDTO studentsAddressDTO)
        {

            if (studentsAddressDTO == null)
                return ResultService.Fail("Objeto deve ser informado!");

            var validation = new StudentsAddressDTOValidation().Validate(studentsAddressDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas na validação dos campos!", validation);

            var response = await _studentsAddressRepository.GetByIdAsync(studentsAddressDTO.Id);
            if (response == null)
                return ResultService.Fail("Registro não encontrado!");

            var student = await _studentsRepository.GetByIdAsync(studentsAddressDTO.StudentId);
            if(student == null)
            {
                return ResultService.Fail<StudentsAddressDTO>("Não conseguimos atualizar, o aluno(a) informado não existe!");
            }
            else
            {
                response.Students.Id = student.Id;
                response.Students.FullName = student.FullName;
                response.Students.BirthDate = student.BirthDate;
                response.Students.Cpf = student.Cpf;
                response.Students.Rg = student.Rg;
                response.Students.Age = student.Age;
                response.Students.isActive = student.isActive;
                response.Students.CreatAt = student.CreatAt;
                response.Students.UpdatAt = student.UpdatAt;
            }

            var city = await _cityRepository.GetById(studentsAddressDTO.CityId);
            if(city == null)
            {
                return ResultService.Fail<StudentsAddressDTO>("Não conseguimos atualizar, a cidade informada não existe!");
            }
            else
            {
                response.Citys.Id = city.Id;
                response.Citys.CityName = city.CityName;
            }

            var state = await _stateRepository.GetById(studentsAddressDTO.StateId);
            if (state == null)
            {
                return ResultService.Fail<StudentsAddressDTO>("Não conseguimos atualizar, o estado informada não existe!");
            }
            else
            {
                response.States.Id = state.Id;
                response.States.StateName = state.StateName;
            }

            var country = await _countryRepository.GetById(studentsAddressDTO.CountryId);
            if (country == null)
            {
                return ResultService.Fail<StudentsAddressDTO>("Não conseguimos atualizar, o país informado não existe!");
            }
            else
            {
                response.Countrys.Id = country.Id;
                response.Countrys.CountryName = country.CountryName;
            }

            var address = await _addressRepository.GetById(studentsAddressDTO.AddressId);
            if (address == null)
            {
                return ResultService.Fail<StudentsAddressDTO>("Não conseguimos atualizar, o endereço informado não existe!");
            }
            else
            {
                response.Address.Id = address.Id;
                response.Address.AddressName = address.AddressName;
            }

            response = _mapper.Map<StudentsAddressDTO, StudentAddress>(studentsAddressDTO, response);

            _studentsAddressRepository.UpdateAsync(response);

            return ResultService.Ok("Registro atualizado com sucesso!");
        }

        public async Task<ResultService<StudentsAddressDTO>> GetByStudentIdAsync(int id)
        {
            var list = await _studentsAddressRepository.GetByStudentIdAsync(id);
            if (list == null)
                return ResultService.Fail<StudentsAddressDTO>("Nenhum registro foi encontrado!");

            return ResultService.Ok<StudentsAddressDTO>(_mapper.Map<StudentsAddressDTO>(list));
        }
    }
}
