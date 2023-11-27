using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task ValidaUserData_Executed_ReturnUserId()
        {
            var authServiceMock = new Mock<IAuthService>();
            var userRepositoryMock = new Mock<IUserRepository>();

            var createUserCommand = new CreateUserCommand("User 1", "username1", "123", "user@email.com", DateTime.Now, "client");
            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            var userId = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            Assert.True(userId != Guid.Empty);

            userRepositoryMock.Verify(ur => ur.AddAsync(It.IsAny<User>()).Result, Times.Once);
        }
    }
}
