using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Aluno
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
        public int Idade { get; set; }

        public bool? isAtivo { get; set; }

        [Required]
        public DateTime CreatAt { get; set; }

        public DateTime? UpdatAt { get; set; }

        public string Cep { get; set; }

        public ICollection<AlunoEndereco> AlunoEnderecos { get; set; }

        public ICollection<AlunoSerie> AlunoSeries { get; set; } = new List<AlunoSerie>();

        public virtual ICollection<AlunoDisciplina> AlunoDisciplinas { get; private set; } = new List<AlunoDisciplina>();

        public Aluno()
        {
        }

        public Aluno(string nomeCompleto, string rg, string cpf, int idade, bool isAtivo)
        {
            Validation(nomeCompleto, rg, cpf, idade);
        }

        public void Validation(string nomeCompleto, string rg, string cpf, int idade)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nomeCompleto), "Nome completo deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(rg), "Rg deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cpf), "Cpf deve ser informado!");

            DomainValidationException.When(idade < 0, "Idade deve ser informada!");

            NomeCompleto = nomeCompleto;
            Rg = rg;
            Cpf = cpf;
            Idade = idade;
        }
    }
}
