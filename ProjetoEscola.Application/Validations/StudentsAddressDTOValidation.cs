using FluentValidation;
using ProjetoEscola.Application.DTO_s;

namespace ProjetoEscola.Application.Validations
{
    public class StudentsAddressDTOValidation : AbstractValidator<AlunoEnderecoDTO>
    {
        public StudentsAddressDTOValidation()
        {
            RuleFor(x => x.EnderecoId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.AlunoId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CidadeId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PaísId)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.EstadoId)
                .NotEmpty()
                .NotNull();
        }
    }
}
