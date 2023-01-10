using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class TeachersSubjectsDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        ///[JsonPropertyName("Código do Professor")]
        public int TeachersId { get; set; }

        //[JsonPropertyName("Código da Disciplina")]
        public int SubjectsId { get; set; }

        //[JsonPropertyName("Professores")]
        public TeachersDTO Teachers { get; set; }

        //[JsonPropertyName("Disciplinas")]
        public SubjectsDTO Subjects { get; set; }
    }
}
