using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private const int PAGE_SIZE = 20;
    private readonly DevFreelaDbContext _dbContext;

    public ProjectRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Project>> GetAllAsync(string query, int page)
    {
        IQueryable<Project> projects = _dbContext.Projects;

        if (!string.IsNullOrEmpty(query))
            projects = projects
                .Where(p => p.Title.Contains(query) || p.Description.Contains(query));

        return await projects.GetPaged(page, PAGE_SIZE);
    }

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
