using AuthKit.Application.DashboardAggregate.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Application.DashboardAggregate.Commands
{
    public class CreateDashboardUserCommand : IRequest<CreateDashboardUserResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
