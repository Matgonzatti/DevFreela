namespace DevFreela.Core.Entities;

public class User : BaseEntity
{
    public User(string name, DateTime birthDate, string email, string password, string role)
    {
        Name = name;
        BirthDate = birthDate;
        Email = email;
        Active = true;
        CreatedAt = DateTime.Now;
        Password = password;
        Role = role;

        Skills = new List<UserSkill>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    public List<UserSkill> Skills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }
    public List<ProjectComments> Comments { get; private set; }
}
