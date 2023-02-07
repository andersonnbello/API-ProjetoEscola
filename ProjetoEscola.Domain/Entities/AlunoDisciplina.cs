using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscola.Domain.Entities
{
    public class AlunoDisciplina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Aluno")]
        public int AlunoId { get; set; }

        [Required]
        public int DisciplinaId { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}
