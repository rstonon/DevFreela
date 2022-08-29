using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //api/projects?query=net core
        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            //buscar todos os objetos
            //var projects = _projectService.GetAll(query);

            var getAll = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAll);

            return Ok(projects);
        }

        //api/projects/3
        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {

            //buscar o objeto
            //var project = _projectService.GetById(id);

            var getById = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(getById);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {

            //cadastrar o objeto
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        //api/projects/3
        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            //atualiza o objeto
            //_projectService.Update(inputModel);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {

            // Remover ou Desativar
            //_projectService.Delete(id);

            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentCommand command)
        {
            //_projectService.CreateComment(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            //_projectService.Start(id);
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            //_projectService.Finish(id);
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
