namespace DevFreela.Application.InputModels;

public class CreateCommentInputModel
{
    public string Content { get; set; }
    public Guid IdProject { get; set; }
    public Guid IdUser { get; set; }
}
