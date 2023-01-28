using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class AddressDTOValidation : AbstractValidator<AddressDTO>
    {
        public AddressDTOValidation()
        {
            RuleFor(x => x.AddressName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cep)
                .NotNull()
                .NotEmpty();
        }
    }
}
