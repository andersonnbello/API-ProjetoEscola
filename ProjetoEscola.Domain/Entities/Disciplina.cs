using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O campo Name deve conter no máximo 20 caractéres")]
        public string NomeDisciplina { get; set; }

        public virtual ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; } = new List<AlunoDisciplina>();

        public virtual ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; } = new List<ProfessorDisciplina>();
    }
}
