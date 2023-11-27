using DevFreela.Application.Queries.GetAllUsers;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllUsersQueryHandlerTests
    {

        [Fact]
        public async Task TwoUsersExists_Executed_ReturnListWithTwoUsers()
        {
            var users = new List<User>
            {
                new User("User 1", DateTime.Now, "a@a.com", "123", "client"),
                new User("User 2", DateTime.Now, "b@b.com", "321", "freelancer")
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(ur => ur.GetAllAsync().Result).Returns(users);

            var getAllUsersQuery = new GetAllUsersQuery();
            var getAllUsersQueryHandler = new GetAllUsersQueryHandler(userRepositoryMock.Object);

            var usersViewModel = await getAllUsersQueryHandler.Handle(getAllUsersQuery, new CancellationToken());

            Assert.NotNull(usersViewModel);
            Assert.NotEmpty(usersViewModel);
            Assert.Equal(usersViewModel.Count, users.Count);

            userRepositoryMock.Verify(ur => ur.GetAllAsync().Result, Times.Once());
        }
    }
}
