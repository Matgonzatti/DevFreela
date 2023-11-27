using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task ProjectId_Executed_ReturnProject()
        {
            //Arrange
            var projectToSearch = new Project("Project 1", "Project description", Guid.NewGuid(), Guid.NewGuid(), 200);

            var projects = new List<Project>
            {
                projectToSearch,
                new Project("Project 2", "Project 2 description", Guid.NewGuid(), Guid.NewGuid(), 200),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetByIdAsync(projectToSearch.Id).Result).Returns(projectToSearch);

            var getProjectByIdQuery = new GetProjectByIdQuery(projectToSearch.Id);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);
            //Act
            var project = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            //Assert
            Assert.Equal(project, projectToSearch);

            projectRepositoryMock.Verify(pr => pr.GetByIdAsync(projectToSearch.Id).Result, Times.Once);
        }
    }
}
