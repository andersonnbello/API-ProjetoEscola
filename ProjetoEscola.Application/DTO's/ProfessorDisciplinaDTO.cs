using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class ProfessorDisciplinaDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Código do Professor")]
        public int ProfessorId { get; set; }

        //[JsonPropertyName("Código da Disciplina")]
        public int DisciplinaId { get; set; }

        //[JsonPropertyName("Professores")]
        public ProfessorDTO Professor { get; set; }

        //[JsonPropertyName("Disciplinas")]
        public DisciplinaDTO Disciplina { get; set; }
    }
}
