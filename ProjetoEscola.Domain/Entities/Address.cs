using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AddressName { get; set; }

        [Required]
        public string Number { get; set; }

        public ICollection<StudentAddress> StudentsAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string Cep { get; set; }

        public Address()
        {
        }

        public Address(string addressName, string number, string cep, int studentsId)
        {
            Validation(addressName, number, cep, studentsId);
        }

        public void Validation(string addressName, string number, string cep, int studentsId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(addressName), "Nome do endereço deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(number), "Numero deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(cep), "Cep deve ser informado!");

            AddressName = addressName;
            Number = number;
            Cep = cep;
        }
    }
}
