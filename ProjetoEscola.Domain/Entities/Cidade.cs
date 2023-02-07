using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Cidade
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeCidade { get; set; }

        public ICollection<AlunoEndereco> AlunoEnderecos { get; set; }


        public Cidade(string nomeCidade)
        {
            Validation(nomeCidade);
        }

        public Cidade()
        {
        }

        public void Validation(string nomeCidade)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nomeCidade), "Nome da cidade deve ser informado!");

            NomeCidade = nomeCidade;
        }
    }
}
