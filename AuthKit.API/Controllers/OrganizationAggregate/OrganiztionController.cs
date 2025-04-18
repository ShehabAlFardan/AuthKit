using AuthKit.API.Dtos.DashboardAggregate;
using AuthKit.API.Dtos.OrganizationAggregate;
using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.OrganizationAggregate.Commands;
using AuthKit.Domain.UserAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthKit.API.Controllers.OrganizationAggregate
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganiztionController : AuthBaseController
    {
        private readonly IMediator _mediator;
        public OrganiztionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization(CreateOrganizationRequest request)
        {
            CreateOrganizationCommand command = new()
            {
                Name = request.Name,
                ApplicationId = request.ApplicationId,
                UserId = UserId,
            };

            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }
    }
}
