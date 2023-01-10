using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Serie
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<StudentSerie> StudentsSeries { get; set; } = new List<StudentSerie>();

        public Serie(string name)
        {
            Validation(name);
        }

        public void Validation(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");

            Name = name;
        }
    }
}
