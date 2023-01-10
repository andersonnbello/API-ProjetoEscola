using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StateDTOValidation : AbstractValidator<StateDTO>
    {
        public StateDTOValidation()
        {
            RuleFor(x => x.StateName)
                .NotNull()
                .NotEmpty();
        }
    }
}
