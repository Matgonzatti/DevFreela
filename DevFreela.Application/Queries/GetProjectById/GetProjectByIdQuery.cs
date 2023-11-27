using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<Project>
{
    public Guid Id { get; private set; }

    public GetProjectByIdQuery(Guid id)
    {
        Id = id;
    }
}
