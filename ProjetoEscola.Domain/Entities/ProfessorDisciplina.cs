using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscola.Domain.Entities
{
    public class ProfessorDisciplina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }

        [Required]
        [ForeignKey("Disciplina")]
        public int  DisciplinaId { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}
