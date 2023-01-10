using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentsSubjectsDTOValidation : AbstractValidator<StudentsSubjectsDTO>
    {
        public StudentsSubjectsDTOValidation()
        {
            RuleFor(x => x.StudentId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.SubjectId)
                .NotNull()
                .NotEmpty();
        }
    }
}
