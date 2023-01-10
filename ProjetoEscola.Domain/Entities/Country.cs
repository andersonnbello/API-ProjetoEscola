using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        public string CountryName { get; set; }

        public ICollection<StudentAddress> StudentsAddress { get; set; }


        public Country(string countryName)
        {
            Validation(countryName);
        }

        public void Validation(string countryName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(countryName), "Nome do Pís deve ser informado!");

            CountryName = countryName;
        }
    }
}
