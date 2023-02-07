using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class TeachersSubjectsDTOValidation : AbstractValidator<ProfessorDisciplinaDTO>
    {
        public TeachersSubjectsDTOValidation()
        {
            RuleFor(x => x.ProfessorId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DisciplinaId)
                .NotNull()
                .NotEmpty();
        }
    }
}
