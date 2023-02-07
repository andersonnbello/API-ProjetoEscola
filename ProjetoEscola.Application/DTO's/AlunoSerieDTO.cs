using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class AlunoSerieDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Código Aluno")]
        public int AlunoId { get; set; }

        //[JsonPropertyName("Código Série")]
        public int SerieId { get; set; }

        public virtual SerieDTO Series { get; set; }

        public virtual AlunoDTO Students { get; set; }
    }
}
