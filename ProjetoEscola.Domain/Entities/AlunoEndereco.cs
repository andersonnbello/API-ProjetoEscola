using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscola.Domain.Entities
{
    public class AlunoEndereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }

        [Required]
        [ForeignKey("Estado")]
        public int EstadoId { get; set; }

        [Required]
        [ForeignKey("Cidade")]
        public int CidadeId { get; set; }

        [Required]
        [ForeignKey("Endereco")]
        public int EnderecoId { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual Endereco Endereco { get; set; } 
    }
}
