using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<AlunoDisciplina, AlunoDisciplinaDTO>().ReverseMap();
            CreateMap<ProfessorDisciplina, ProfessorDisciplinaDTO>().ReverseMap();
            CreateMap<Disciplina, DisciplinaDTO>().ReverseMap();
            CreateMap<Professor, ProfessorDTO>().ReverseMap();
            CreateMap<Estado, EstadoDTO>().ReverseMap();
            CreateMap<Cidade, CidadeDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<AlunoEndereco, AlunoEnderecoDTO>().ReverseMap();
            CreateMap<Serie, SerieDTO>().ReverseMap();
            CreateMap<AlunoSerie, AlunoSerieDTO>().ReverseMap();
        }
    }
}
