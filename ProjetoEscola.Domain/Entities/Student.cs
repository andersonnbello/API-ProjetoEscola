using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Student
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
        public int Age { get; set; }

        public bool? isActive { get; set; }

        [Required]
        public DateTime CreatAt { get; set; }

        public DateTime? UpdatAt { get; set; }

        public ICollection<StudentAddress> StudentsAddress { get; set; }

        public ICollection<StudentSerie> StudentsSeries { get; set; } = new List<StudentSerie>();

        public virtual ICollection<StudentSubject> StudentsSubjects { get; private set; } = new List<StudentSubject>();

        public Student()
        {
        }

        public Student(string fullname, string rg, string cpf, int age, bool isActive)
        {
            Validation(fullname, rg, cpf, age);
        }

        public void Validation(string fullname, string rg, string cpf, int age)
        {
            DomainValidationException.When(string.IsNullOrEmpty(fullname), "Nome completo deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(rg), "Rg deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cpf), "Cpf deve ser informado!");

            DomainValidationException.When(age < 0, "Idade deve ser informada!");

            FullName = fullname;
            Rg = rg;
            Cpf = cpf;
            Age = age;
        }
    }
}
