using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class SerieDTOValidation : AbstractValidator<SerieDTO>
    {
        public SerieDTOValidation()
        {
            RuleFor(x => x.NomeSerie)
                .NotEmpty()
                .NotNull();
        }
    }
}
