using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly string _connectionString;
    private readonly DevFreelaDbContext _dbContext;

    public SkillRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreelaCs");
        _dbContext = dbContext;
    }

    public async Task<List<SkillDTO>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString)) {
            sqlConnection.Open();

            var script = "SELECT Id, Description FROM Skills";

            var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

            return skills.ToList();
        }
    }

    public async Task AddSkillFromProject(Project project)
    {
        var words = project.Description.Split(' ');

        var length = words.Length;

        var skill = $"{project.Id} - {words[length - 1]}";

        await _dbContext.Skills.AddAsync(new Skill(skill));
    }
}
