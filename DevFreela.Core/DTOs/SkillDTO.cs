namespace DevFreela.Core.DTOs;

public class SkillDTO
{
    public SkillDTO(Guid id, string description)
    {
        Id = id;
        Description = description;
    }

    public Guid Id { get; private set; }
    public string Description { get; private set; }
}
