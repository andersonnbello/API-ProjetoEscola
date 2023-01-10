using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentsAddressDTOValidation : AbstractValidator<StudentsAddressDTO>
    {
        public StudentsAddressDTOValidation()
        {
            RuleFor(x => x.AddressId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.StudentId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CityId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.StateId)
                .NotEmpty()
                .NotNull();
        }
    }
}
