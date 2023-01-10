using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "O campo Name deve conter no máximo 20 caractéres")]
        public string Name { get; set; }

        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new List<StudentSubject>();

        public virtual ICollection<TeacherSubject> TeachersSubjects { get; set; } = new List<TeacherSubject>();
    }
}
