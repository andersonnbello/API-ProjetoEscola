using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeEstado { get; set; }

        public ICollection<AlunoEndereco> AlunoEnderecos { get; set; }


        public Estado(string nomeEstado)
        {
            Validation(nomeEstado);
        }

        public Estado()
        {
        }

        public void Validation(string nomeEstado)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nomeEstado), "O nome do Estado deve ser informado!");

            NomeEstado = nomeEstado;
        }
    }
}
