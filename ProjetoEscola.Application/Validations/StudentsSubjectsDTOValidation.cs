using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentsSubjectsDTOValidation : AbstractValidator<AlunoDisciplinaDTO>
    {
        public StudentsSubjectsDTOValidation()
        {
            RuleFor(x => x.AlunoId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DisciplinaId)
                .NotNull()
                .NotEmpty();
        }
    }
}
