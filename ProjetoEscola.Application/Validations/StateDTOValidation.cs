using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StateDTOValidation : AbstractValidator<EstadoDTO>
    {
        public StateDTOValidation()
        {
            RuleFor(x => x.NomeEstado)
                .NotNull()
                .NotEmpty();
        }
    }
}
