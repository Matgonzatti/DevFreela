using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project : BaseEntity
{
    public Project(string title, string description, Guid idClient, Guid idFreelancer, decimal totalCost)
    {
        Title = title;
        Description = description;
        IdClient = idClient;
        IdFreelancer = idFreelancer;
        TotalCost = totalCost;
        CreatedAt = DateTime.Now;
        Status = ProjectStatusEnum.Created;

        Comments = new List<ProjectComments>();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid IdClient { get; private set; }
    public User Client { get; private set; }
    public Guid IdFreelancer { get; private set; }
    public User Freelancer { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatusEnum Status { get; private set; }
    public List<ProjectComments> Comments { get; private set; }

    public void Cancel() {
        if (Status == ProjectStatusEnum.InProgress && Status == ProjectStatusEnum.Created)
            Status = ProjectStatusEnum.Canceled;
    }

    public void Start() {
        if (Status == ProjectStatusEnum.Created) {
            Status = ProjectStatusEnum.InProgress;
            StartedAt = DateTime.Now;
        }
    }

    public void SetPaymentPending()
    {
        Status = ProjectStatusEnum.PendingPayment;
    }

    public void Finish() {
        if (Status == ProjectStatusEnum.PendingPayment) {
            Status = ProjectStatusEnum.Finished;
            FinishedAt = DateTime.Now;
        }
    }

    public void Update(string title, string description, decimal totalCost) {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}
