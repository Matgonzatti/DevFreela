using DevFreela.Application.Commands.CreateComments;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    //[Authorize(Roles = "client, freelancer, admin")]
    public async Task<IActionResult> Get(GetAllProjectsQuery getAllProjectsQuery)
    {
        var projects = await _mediator.Send(getAllProjectsQuery);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "client, freelancer, admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetProjectByIdQuery(id);

        var project = await _mediator.Send(query);

        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    //[Authorize(Roles = "client, admin")]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction($"{nameof(GetById)}", new { id }, command);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "client, admin")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "client, admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    //[Authorize(Roles = "client, freelancer, admin")]
    public async Task<IActionResult> PostComments(Guid id, [FromBody] CreateCommentsCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    //[Authorize(Roles = "client, admin")]
    public async Task<IActionResult> Start(Guid id)
    {
        var command = new StartProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    //[Authorize(Roles = "client, admin")]
    public async Task<IActionResult> Finish([FromBody] FinishProjectCommand command)
    {
        await _mediator.Send(command);

        return Accepted();
    }
}
