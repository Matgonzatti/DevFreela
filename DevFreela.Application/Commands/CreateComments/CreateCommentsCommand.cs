using MediatR;

namespace DevFreela.Application.Commands.CreateComments;

public class CreateCommentsCommand : IRequest<Unit>
{
    public string Content { get; set; }
    public Guid IdProject { get; set; }
    public Guid IdUser { get; set; }
}
