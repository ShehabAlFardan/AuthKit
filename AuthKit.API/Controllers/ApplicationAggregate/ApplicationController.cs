using AuthKit.API.Dtos.ApplicationAggregate;
using AuthKit.API.Dtos.DashboardAggregate;
using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.DashboardAggregate.Commands;
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
        public ApplicationController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}
