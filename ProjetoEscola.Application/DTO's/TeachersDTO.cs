using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoEscola.Application.DTO_s
{
    public class TeachersDTO
    {
        //[JsonPropertyName("Código")]
        public int Id { get; set; }

        //[JsonPropertyName("Nome Completo")]
        public string FullName { get; set; }

        //[JsonPropertyName("Data de Nascimento")]
        public DateTime BirthDate { get; set; }

        //[JsonPropertyName("Numero do RG")]
        public string Rg { get; set; }

        //[JsonPropertyName("Numero do CPF")]
        public string Cpf { get; set; }

        //[JsonPropertyName("Data de Cadastro")]
        public DateTime CreatAt { get; set; }

        //[JsonPropertyName("Data de Atualização")]
        public DateTime UpdatAt { get; set; }
    }
}
