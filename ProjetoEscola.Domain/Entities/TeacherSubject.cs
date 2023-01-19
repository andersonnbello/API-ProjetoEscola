using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscola.Domain.Entities
{
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Teachers")]
        public int TeacherId { get; set; }

        [Required]
        [ForeignKey("Subjects")]
        public int  SubjectId { get; set; }

        public virtual Teacher Teachers { get; set; }

        public virtual Subject Subjects { get; set; }
    }
}
