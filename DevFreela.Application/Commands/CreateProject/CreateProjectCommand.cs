using MediatR;

namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IdClient { get; set; }
    public Guid IdFreelancer { get; set; }
    public decimal TotalCost { get; set; }
}
