using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentSerieDTOValidation : AbstractValidator<StudentSerieDTO>
    {
        public StudentSerieDTOValidation()
        {
            RuleFor(x => x.SerieId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.StudentId)
                .NotEmpty()
                .NotNull();
        }
    }
}
