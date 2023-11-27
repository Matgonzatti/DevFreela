using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<User>
{
    public Guid Id { get; private set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
