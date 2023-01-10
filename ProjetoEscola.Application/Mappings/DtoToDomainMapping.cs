using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<StudentsDTO, Student>().ReverseMap();
            CreateMap<StudentsSubjectsDTO, StudentSubject>().ReverseMap();
            CreateMap<TeachersSubjectsDTO, TeacherSubject>().ReverseMap();
            CreateMap<SubjectsDTO, Subject>().ReverseMap();
            CreateMap<TeachersDTO, Teacher>().ReverseMap();
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<StateDTO, State>().ReverseMap();
            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<CountryDTO, Country>().ReverseMap();
            CreateMap<StudentsAddressDTO, StudentAddress>().ReverseMap();
            CreateMap<SerieDTO, Serie>().ReverseMap();
            CreateMap<StudentSerieDTO, StudentSerie>().ReverseMap();
        }
    }
}
