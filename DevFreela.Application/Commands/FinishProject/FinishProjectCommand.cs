using MediatR;

namespace DevFreela.Application.Commands.FinishProject;

public class FinishProjectCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public FinishProjectCommand(Guid id)
    {
        Id = id;
    }

}
