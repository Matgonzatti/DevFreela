using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Project>> GetAllAsync() => await _dbContext.Projects.ToListAsync();

    public async Task<Project> GetByIdAsync(Guid id)
    {   
        var project = await _dbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefaultAsync(p => p.Id == id);

        if (project is null) return null;

        return project;
    }

    public async Task<Guid> AddAsync(Project project)
    {
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();

        return project.Id;
    }

    public async Task DeleteAsync(Guid id)
    {
        var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
        
        project.Cancel();

        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateCommentAsync(ProjectComments projectComments)
    {
        await _dbContext.ProjectComments.AddAsync(projectComments);
        await _dbContext.SaveChangesAsync();
    }

}
