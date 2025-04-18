using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Application.OrganizationAggregate.Dtos
{
    public class CreateOrganizationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
