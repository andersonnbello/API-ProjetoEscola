using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class TeachersSubjectsDTOValidation : AbstractValidator<TeachersSubjectsDTO>
    {
        public TeachersSubjectsDTOValidation()
        {
            RuleFor(x => x.TeachersId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.SubjectsId)
                .NotNull()
                .NotEmpty();
        }
    }
}
