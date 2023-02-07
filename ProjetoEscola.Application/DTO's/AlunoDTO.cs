using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class AlunoDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Nome completo")]
        public string NomeCompleto { get; set; }

        //[JsonPropertyName("Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        //[JsonPropertyName("Número do RG")]
        public string Rg { get; set; }

        //[JsonPropertyName("Número do CPF")]
        public string Cpf { get; set; }

        //[JsonPropertyName("Idade")]
        public int Idade { get; set; }

        //[JsonPropertyName("Ativo")]
        public bool isAtivo { get; set; }

        //[JsonPropertyName("Data de cadastro")]
        public DateTime CreatAt { get; set; }

        //[JsonPropertyName("Data de atualização")]
        public DateTime? UpdatAt { get; set; }

        public string Cep { get; set; }
    }
}
