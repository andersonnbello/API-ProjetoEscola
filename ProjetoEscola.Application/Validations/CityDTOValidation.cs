using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class CityDTOValidation : AbstractValidator<CidadeDTO>
    {
        public CityDTOValidation()
        {
            RuleFor(x => x.NomeCidade)
                .NotEmpty()
                .NotNull();
        }
    }
}
