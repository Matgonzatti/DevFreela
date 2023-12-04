using MediatR;

namespace DevFreela.Application.Commands.FinishProject;

public class FinishProjectCommand : IRequest<Unit>
{
    public FinishProjectCommand(Guid id, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
    {
        Id = id;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
        Amount = amount;
    }

    public Guid Id { get; set; }
    public string CreditCardNumber { get; set; }
    public string Cvv { get; set; }
    public string ExpiresAt { get; set; }
    public string FullName { get; set; }
    public decimal Amount { get; set; }

}
