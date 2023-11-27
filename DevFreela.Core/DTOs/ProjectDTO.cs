namespace DevFreela.Core.DTOs;

public class ProjectDTO
{
    public ProjectDTO(Guid id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishedAt, string clientName, string freelanceName)
    {
        Id = id;
        Title = title;
        Description = description;
        TotalCost = totalCost;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        ClientName = clientName;
        FreelancerName = freelanceName;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public string ClientName { get; private set; }
    public string FreelancerName { get; private set; }
}
