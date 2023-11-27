using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.CreateComments;

public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentsCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(CreateCommentsCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComments(request.Content, request.IdProject, request.IdUser);

        await _projectRepository.CreateCommentAsync(comment);

        return Unit.Value;
    }

}
