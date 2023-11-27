using MediatR;

namespace DevFreela.Application.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }

    public DeleteProjectCommand(Guid id)
    {
        Id = id;
    }
}
