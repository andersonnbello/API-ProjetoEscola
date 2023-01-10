using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class StudentSerie
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SerieId { get; set; }

        public virtual Serie Series { get; set; }

        public virtual Student Students { get; set; }

        //public int idade { get; set; }

        public StudentSerie(int studentId, int serieId)
        {
            Validation(studentId, serieId);
        }

        public void Validation(int studentId, int serieId)
        {
            DomainValidationException.When(studentId <= 0, "Student deve ser informado!");
            DomainValidationException.When(serieId <= 0, "Série deve ser informado!");

            StudentId = studentId;
            SerieId = serieId;
        }
    }
}
