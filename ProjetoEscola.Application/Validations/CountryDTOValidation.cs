using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class CountryDTOValidation : AbstractValidator<CountryDTO>
    {
        public CountryDTOValidation()
        {
            RuleFor(x => x.CountryName)
                .NotEmpty()
                .NotNull();
        }
    }
}
