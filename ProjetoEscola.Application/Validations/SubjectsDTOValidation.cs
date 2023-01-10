using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class SubjectsDTOValidation : AbstractValidator<SubjectsDTO>
    {
        public SubjectsDTOValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
