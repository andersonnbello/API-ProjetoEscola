using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class DisciplinaDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Disciplina")]
        public string NomeDisciplina { get; set; }
    }
}
