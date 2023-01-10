using ProjetoEscola.Domain.Entities;

namespace ProjetoEscola.Application.DTO_s
{
    public class StudentSerieDTO
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SerieId { get; set; }

        public virtual SerieDTO Series { get; set; }

        public virtual StudentsDTO Students { get; set; }
    }
}
