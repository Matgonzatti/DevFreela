using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence.Models;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task<PaginationResult<Project>> GetAllAsync(string query, int page = 1);
    Task<Project> GetByIdAsync(Guid id);
    Task<Guid> AddAsync(Project project);
    Task DeleteAsync(Guid id);
    Task CreateCommentAsync(ProjectComments projectComments);
    Task SaveChangesAsync();
}
