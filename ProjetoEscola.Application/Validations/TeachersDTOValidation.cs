using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class TeachersDTOValidation : AbstractValidator<ProfessorDTO>
    {
        public TeachersDTOValidation()
        {
            RuleFor(x => x.NomeCompleto)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cpf)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Rg)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .NotEmpty();
        }
    }
}
