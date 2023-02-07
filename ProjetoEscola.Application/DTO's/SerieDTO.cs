using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class SerieDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Nome da série")]
        public string NomeSerie { get; set; }
    }
}
