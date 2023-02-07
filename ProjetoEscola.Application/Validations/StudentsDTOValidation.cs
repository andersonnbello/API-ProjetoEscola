using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentsDTOValidation : AbstractValidator<AlunoDTO>
    {
        public StudentsDTOValidation()
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

            RuleFor(x => x.Idade)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .NotEmpty();
        }
    }
}
