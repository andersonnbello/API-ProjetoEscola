using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeEndereco { get; set; }

        [Required]
        public string Numero { get; set; }

        public ICollection<AlunoEndereco> AlunoEnderecos { get; set; }

        [Required]
        [StringLength(20)]
        public string Cep { get; set; }

        public Endereco()
        {
        }

        public Endereco(string nomeEndereco, string numero, string cep, int alunoId)
        {
            Validation(nomeEndereco, numero, cep, alunoId);
        }

        public void Validation(string nomeEndereco, string numero, string cep, int alunoId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nomeEndereco), "Nome do endereço deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(numero), "Numero deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cep), "Cep deve ser informado!");

            NomeEndereco = nomeEndereco;
            Numero = numero;
            Cep = cep;
        }
    }
}
