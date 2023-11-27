using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var hashPassword = _authService.ComputeSha256Hash(request.PassWord);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, hashPassword);

            if (user is null)
                return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var authenticatedUser = new LoginUserViewModel(user.Email, token);

            return authenticatedUser;
        }
    }
}
