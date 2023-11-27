namespace DevFreela.API.Models;
public class CreateProjectModel
{
    public Guid Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public CreateProjectModel(string title, string description)
    {
        Id = Guid.NewGuid();

        Title = title;
        Description = description;
    }
}
