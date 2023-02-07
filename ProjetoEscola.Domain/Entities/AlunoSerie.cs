using ProjetoEscola.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscola.Domain.Entities
{
    public class AlunoSerie
    {
        [Key]
        public int Id { get; set; }

        public int AlunoId { get; set; }

        public int SerieId { get; set; }

        public virtual Serie Series { get; set; }

        public virtual Aluno Aluno { get; set; }

        public AlunoSerie(int alunoId, int serieId)
        {
            Validation(alunoId, serieId);
        }

        public void Validation(int alunoId, int serieId)
        {
            DomainValidationException.When(alunoId <= 0, "Student deve ser informado!");
            DomainValidationException.When(serieId <= 0, "Série deve ser informado!");

            AlunoId = alunoId;
            SerieId = serieId;
        }
    }
}
