using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentsDTOValidation : AbstractValidator<StudentsDTO>
    {
        public StudentsDTOValidation()
        {
            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Rg)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Age)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.BirthDate)
                .NotNull()
                .NotEmpty();
        }
    }
}
