using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class CityDTOValidation : AbstractValidator<CityDTO>
    {
        public CityDTOValidation()
        {
            RuleFor(x => x.CityName)
                .NotEmpty()
                .NotNull();
        }
    }
}
