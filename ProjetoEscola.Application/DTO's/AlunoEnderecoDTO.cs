using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class AlunoEnderecoDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Código do aluno")]
        public int AlunoId { get; set; }

        //[JsonPropertyName("Código do país")]
        public int PaísId { get; set; }

        //[JsonPropertyName("Código do estado")]
        public int EstadoId { get; set; }

        //[JsonPropertyName("Código da cidade")]
        public int CidadeId { get; set; }

        //[JsonPropertyName("Código do endereço")]
        public int EnderecoId { get; set; }

        public virtual AlunoDTO Aluno { get; set; }

        public virtual EstadoDTO Estado { get; set; }

        public virtual CidadeDTO Cidade { get; set; }

        public virtual EnderecoDTO Endereco { get; set; }
    }
}
