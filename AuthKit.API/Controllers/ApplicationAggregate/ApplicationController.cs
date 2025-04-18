using AuthKit.API.Dtos.ApplicationAggregate;
using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthKit.API.Controllers.ApplicationAggregate
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : AuthBaseController
    {
        private readonly IMediator _mediator;
        private readonly IApplicationQueries _applicationQueries;
        public ApplicationController(IMediator mediator, IApplicationQueries applicationQueries)
        {
            _mediator = mediator;
            _applicationQueries = applicationQueries;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(CreateApplicationRequest request)
        {
            CreateApplicationCommand command = new()
            {
                UserId = UserId,
                Name = request.Name,
                ApplicationType = request.ApplicationType
            };

            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(UpdateApplicationRequest request)
        {
            UpdateApplicationCommand command = new()
            {
                DashboardUserId = UserId,
                ApplicationId = request.ApplicationId,
                Name = request.Name,
                ApplicationType = request.ApplicationType
            };

            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(DeleteApplicationRequest request)
        {
            DeleteApplicationCommand command = new()
            {
                DashboardUserId = UserId,
                ApplicationId = request.ApplicationId,
            };

            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [HttpGet("{ApplicationId}")]
        public async Task<IActionResult> GetApplicationById([FromRoute] Guid ApplicationId)
        {
            var application = await _applicationQueries.GetApplicationById(ApplicationId, UserId);

            if (application == null)
            {
                return NotFound($"Application with ID {ApplicationId} not found.");
            }

            return Ok(application);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetApplications()
        {
            var applications = await _applicationQueries.GetApplicationsByDashboardUserId(UserId);

            return Ok(applications);
        }
    }
}
