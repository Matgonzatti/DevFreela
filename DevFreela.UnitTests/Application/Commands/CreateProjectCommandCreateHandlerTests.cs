using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandCreateHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var projectRepository = new Mock<IProjectRepository>();
            var skillRepository = new Mock<ISkillRepository>();

            unitOfWork.SetupGet(uow => uow.Projects).Returns(projectRepository.Object);
            unitOfWork.SetupGet(uow => uow.Skills).Returns(skillRepository.Object);

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Project title",
                Description = "Project description",
                IdClient = Guid.NewGuid(),
                IdFreelancer = Guid.NewGuid(),
                TotalCost = 100
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(unitOfWork.Object);

            //Act
            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert
            Assert.True(id != Guid.Empty);

            projectRepository.Verify(pr => pr.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
