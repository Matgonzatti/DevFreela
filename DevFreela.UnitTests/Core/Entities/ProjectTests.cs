using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var client = new User("Client User", DateTime.Now, "a@a.com", "123", "client");
            var freelancer = new User("Freelancer User", DateTime.Now, "a@a.com", "123", "freelancer");

            var project = new Project("Test Project", "Project description", client.Id, freelancer.Id, 100);


            Assert.NotEmpty(project.Title);
            Assert.NotNull(project.Title);

            Assert.NotEmpty(project.Description);
            Assert.NotNull(project.Description);

            Assert.NotEqual(project.IdClient, project.IdFreelancer);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }
    }
}
