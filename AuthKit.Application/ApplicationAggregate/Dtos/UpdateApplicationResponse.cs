using AuthKit.Domain.Kernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Application.ApplicationAggregate.Dtos
{
    public class UpdateApplicationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
    }
}
