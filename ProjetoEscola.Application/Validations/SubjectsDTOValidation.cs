using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class SubjectsDTOValidation : AbstractValidator<DisciplinaDTO>
    {
        public SubjectsDTOValidation()
        {
            RuleFor(x => x.NomeDisciplina)
                .NotEmpty()
                .NotNull();
        }
    }
}
