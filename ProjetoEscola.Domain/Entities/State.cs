using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        public string StateName { get; set; }

        public ICollection<StudentAddress> StudentsAddress { get; set; }


        public State(string stateName)
        {
            Validation(stateName);
        }

        public void Validation(string stateName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(stateName), "O nome do Estado deve ser informado!");

            StateName = stateName;
        }
    }
}
