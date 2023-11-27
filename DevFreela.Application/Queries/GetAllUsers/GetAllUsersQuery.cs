using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<User>>
{
}
