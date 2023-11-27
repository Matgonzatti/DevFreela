using DevFreela.Application.Queries.GetAllSkills;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllSkillsQueryHandlerTests
    {
        [Fact]
        public async Task ThreeSkills_Executed_ReturnThreeSkillViewModel()
        {
            var skills = new List<SkillDTO>
            {
                new SkillDTO(Guid.NewGuid(), ".NET Developer"),
                new SkillDTO(Guid.NewGuid(), "Azure DevOps"),
                new SkillDTO(Guid.NewGuid(), "ASPNET Core")
            };

            var skillRepositoryMock = new Mock<ISkillRepository>();
            skillRepositoryMock.Setup(sr => sr.GetAllAsync().Result).Returns(skills);

            var getAllSkillQuery = new GetAllSkillsQuery();
            var getAllSkillQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            var skillViewModel = await getAllSkillQueryHandler.Handle(getAllSkillQuery, new CancellationToken());

            Assert.NotNull(skillViewModel);
            Assert.NotEmpty(skillViewModel);
            Assert.Equal(skillViewModel.Count, skills.Count);

            skillRepositoryMock.Verify(sr => sr.GetAllAsync(), Times.Once);
        }
    }
}
