using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscola.Domain.Entities
{
    public class StudentSubject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Students")]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public virtual Student Students { get; set; }

        public virtual Subject Subjects { get; set; }
    }
}
