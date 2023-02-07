using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class AddressDTOValidation : AbstractValidator<EnderecoDTO>
    {
        public AddressDTOValidation()
        {
            RuleFor(x => x.NomeEndereco)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cep)
                .NotNull()
                .NotEmpty();
        }
    }
}
