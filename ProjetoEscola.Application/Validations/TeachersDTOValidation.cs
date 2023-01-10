using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class TeachersDTOValidation : AbstractValidator<TeachersDTO>
    {
        public TeachersDTOValidation()
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

            RuleFor(x => x.BirthDate)
                .NotNull()
                .NotEmpty();
        }
    }
}
