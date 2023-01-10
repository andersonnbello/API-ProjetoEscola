using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Student, StudentsDTO>().ReverseMap();
            CreateMap<StudentSubject, StudentsSubjectsDTO>().ReverseMap();
            CreateMap<TeacherSubject, TeachersSubjectsDTO>().ReverseMap();
            CreateMap<Subject, SubjectsDTO>().ReverseMap();
            CreateMap<Teacher, TeachersDTO>().ReverseMap();
            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<StudentAddress, StudentsAddressDTO>().ReverseMap();
            CreateMap<Serie, SerieDTO>().ReverseMap();
            CreateMap<StudentSerie, StudentSerieDTO>().ReverseMap();
        }
    }
}
