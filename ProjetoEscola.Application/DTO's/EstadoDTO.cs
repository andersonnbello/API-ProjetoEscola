using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class EstadoDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Nome do estado")]
        public string NomeEstado { get; set; }
    }
}
