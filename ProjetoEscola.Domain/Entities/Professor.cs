using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? NomeCompleto { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(20)]
        public string? Rg { get; set; }

        [Required]
        [StringLength(20)]
        public string? Cpf { get; set; }

        [Required]
        public DateTime CreatAt { get; set; }

        public DateTime? UpdatAt { get; set; }

        public virtual ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; } = new List<ProfessorDisciplina>();

        public Professor()
        {
        }

        public Professor(string nomeCompleto, string rg, string cpf)
        {
            Validation(nomeCompleto, rg, cpf);
        }

        public void Validation(string nomeCompleto, string rg, string cpf)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nomeCompleto), "Nome completo deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(rg), "Rg deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cpf), "Cpf deve ser informado!");

            NomeCompleto = nomeCompleto;
            Rg = rg;
            Cpf = cpf;
        }
    }
}
