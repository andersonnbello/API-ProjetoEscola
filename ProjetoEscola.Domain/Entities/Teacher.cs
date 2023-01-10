using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FullName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(20)]
        public string? Rg { get; set; }

        [Required]
        [StringLength(20)]
        public string? Cpf { get; set; }

        [Required]
        public DateTime CreatAt { get; set; }

        public DateTime? UpdatAt { get; set; }

        public virtual ICollection<TeacherSubject> TeachersSubjects { get; set; } = new List<TeacherSubject>();

        public Teacher()
        {
        }

        public Teacher(string fullName, string rg, string cpf)
        {
            Validation(fullName, rg, cpf);
        }

        public void Validation(string fullName, string rg, string cpf)
        {
            DomainValidationException.When(string.IsNullOrEmpty(fullName), "Nome completo deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(rg), "Rg deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cpf), "Cpf deve ser informado!");

            FullName = fullName;
            Rg = rg;
            Cpf = cpf;
        }
    }
}
