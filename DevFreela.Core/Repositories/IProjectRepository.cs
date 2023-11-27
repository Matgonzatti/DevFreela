using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<List<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Project project);
    Task DeleteAsync(Guid id);
    Task CreateCommentAsync(ProjectComments projectComments);
    Task SaveChangesAsync();
}
