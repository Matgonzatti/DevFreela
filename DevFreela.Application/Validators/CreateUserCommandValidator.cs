using System.Text.RegularExpressions;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email)
            .EmailAddress()
            .WithMessage("E-mail inválido!");

        RuleFor(p => p.Password)
            .Must(ValidPassword)
            .WithMessage("Senha inválida!");

        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigatório!");
    }

    public bool ValidPassword(string password) {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
