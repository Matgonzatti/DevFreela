using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {
        public LoginUserCommand(string email, string passWord)
        {
            Email = email;
            PassWord = passWord;
        }

        public string Email { get; private set; }
        public string PassWord { get; private set; }
    }
}
