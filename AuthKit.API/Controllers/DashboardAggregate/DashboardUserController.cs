using AuthKit.API.Dtos.DashboardAggregate;
using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Domain.UserAggregate;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthKit.API.Controllers.DashboardAggregate
{
    public class DashboardUserController : Controller
    {
        private readonly IMediator _mediator;

        public DashboardUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateDashboardUserRequest request)
        {
            CreateDashboardUserCommand command = new()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };

            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDashboardUserRequest request)
        {
            LoginDashboardUserCommand command = new()
            {
                Email = request.Email,
                Password = request.Password
            };

            var commandResult = await _mediator.Send(command);

            return Ok(commandResult);
        }
    }
}
