using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class AlunoDisciplinaDTO
    {
        [JsonPropertyName("Código")]
        public int Id { get; set; }

        [JsonPropertyName("Código do aluno")]
        public int AlunoId { get; set; }

        [JsonPropertyName("Código da disciplina")]
        public int DisciplinaId { get; set; }

        public virtual AlunoDTO Alunos { get; set; }

        public virtual DisciplinaDTO Disciplina { get; set; }
    }
}
