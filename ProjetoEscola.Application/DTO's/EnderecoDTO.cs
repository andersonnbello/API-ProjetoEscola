using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class EnderecoDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Nome do endereço")]
        public string NomeEndereco { get; set; }

        //[JsonPropertyName("Número")]
        public string Numero { get; set; }

        //[JsonPropertyName("CEP")]
        public string Cep { get; set; }
   }
}
