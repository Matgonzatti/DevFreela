using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

        await _unitOfWork.BeginTransactionAsync();

        await _unitOfWork.Projects.AddAsync(project);

        await _unitOfWork.CompleteAsync();

        await _unitOfWork.Skills.AddSkillFromProject(project);

        await _unitOfWork.CompleteAsync();

        await _unitOfWork.CommitAsync();

        return project.Id;
    }
}