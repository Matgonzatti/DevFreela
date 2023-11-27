using DevFreela.Application.Commands.CreateComments;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateCommentsCommandValidator : AbstractValidator<CreateCommentsCommand>
    {
        public CreateCommentsCommandValidator()
        {
            RuleFor(p => p.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(5000)
                .WithMessage("Tamanho máximo do comentário é de 5000 caracteres!");
        }
    }
}