using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExists_Executed_ReturnThreeProjectViewModel()
        {
            //Arrange
            var projects = new List<Project>
            {
                new Project("Project 1", "Decription 1", Guid.NewGuid(), Guid.NewGuid(), 100),
                new Project("Project 2", "Decription 2", Guid.NewGuid(), Guid.NewGuid(), 200),
                new Project("Project 3", "Decription 3", Guid.NewGuid(), Guid.NewGuid(), 300),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            //Act
            var projectViewModel = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModel);
            Assert.NotEmpty(projectViewModel);
            Assert.Equal(projects.Count, projectViewModel.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
