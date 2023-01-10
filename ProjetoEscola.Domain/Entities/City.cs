using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class City
    {

        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }

        public ICollection<StudentAddress> StudentsAddress { get; set; }


        public City(string cityName)
        {
            Validation(cityName);
        }

        public void Validation(string cityName)
        {
            DomainValidationException.When(string.IsNullOrEmpty(cityName), "Nome da cidade deve ser informado!");

            CityName = cityName;
        }
    }
}
