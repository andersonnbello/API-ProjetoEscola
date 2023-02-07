using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class CidadeDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Nome da cidade")]
        public string NomeCidade { get; set; }
    }
}
