using AutoMapper;
using ProjetoEscola.Application.DTO_s;
using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<AlunoDTO, Aluno>().ReverseMap();
            CreateMap<AlunoDisciplinaDTO, AlunoDisciplina>().ReverseMap();
            CreateMap<ProfessorDisciplinaDTO, ProfessorDisciplina>().ReverseMap();
            CreateMap<DisciplinaDTO, Disciplina>().ReverseMap();
            CreateMap<ProfessorDTO, Professor>().ReverseMap();
            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<EstadoDTO, Estado>().ReverseMap();
            CreateMap<CidadeDTO, Cidade>().ReverseMap();
            CreateMap<AlunoEnderecoDTO, AlunoEndereco>().ReverseMap();
            CreateMap<SerieDTO, Serie>().ReverseMap();
            CreateMap<AlunoSerieDTO, AlunoSerie>().ReverseMap();
        }
    }
}
