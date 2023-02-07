using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Serie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string NomeSerie { get; set; }

        public int Categoria { get; set; }

        public ICollection<AlunoSerie> AlunoSeries { get; set; } = new List<AlunoSerie>();

        public Serie(string nomeSerie)
        {
            Validation(nomeSerie);
        }

        public void Validation(string nomeSerie)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nomeSerie), "Nome deve ser informado!");

            NomeSerie = nomeSerie;
        }
    }
}
