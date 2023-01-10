using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class StudentsSubjectsDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Coódigo do Aluno")]
        public int StudentId { get; set; }

        //[JsonPropertyName("Coódigo da Disciplina")]
        public int SubjectId { get; set; }

        //[JsonPropertyName("Alunos")]
        public virtual StudentsDTO Students { get; set; }

        //[JsonPropertyName("Disciplinas")]
        public virtual SubjectsDTO Subjects { get; set; }
    }
}
