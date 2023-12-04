using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;

    public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        var paymentInfDto = new PaymentInfoDTO(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount);

        _paymentService.Process(paymentInfDto);

        project.SetPaymentPending();

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }

}
