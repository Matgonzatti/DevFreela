using MediatR;

namespace DevFreela.Application.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
}
