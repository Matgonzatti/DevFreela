using MediatR;

namespace DevFreela.Application.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public CreateUserCommand(string name, string userName, string password, string email, DateTime birthDate, string role)
    {
        Name = name;
        UserName = userName;
        Password = password;
        Email = email;
        BirthDate = birthDate;
        Role = role;
    }


    public string Name { get; private set; }
    public string UserName { get; private set; } 
    public string Password { get; private set; } 
    public string Email { get; private set; } 
    public string Role { get; private set; }
    public DateTime BirthDate { get; private set; }
}
