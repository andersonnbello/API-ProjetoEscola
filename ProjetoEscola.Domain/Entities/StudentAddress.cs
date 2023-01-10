using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEscola.Domain.Entities
{
    public class StudentAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Students")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("Countrys")]
        public int CountryId { get; set; }

        [Required]
        [ForeignKey("States")]
        public int StateId { get; set; }

        [Required]
        [ForeignKey("Citys")]
        public int CityId { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [Required]
        public int Number { get; set; }

        public virtual Student Students { get; set; }

        public virtual Country Countrys { get; set; }

        public virtual State States { get; set; }

        public virtual City Citys { get; set; }

        public virtual Address Address { get; set; } 
    }
}
