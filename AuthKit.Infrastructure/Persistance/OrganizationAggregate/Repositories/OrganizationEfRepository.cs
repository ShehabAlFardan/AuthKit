using AuthKit.Domain.OrganizationAggregate;
using AuthKit.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Infrastructure.Persistance.OrganizationAggregate.Repositories
{
    public class OrganizationEfRepository : EfRepository<ApplicationDbContext, Organization, Guid>, IOrganizationRepository
    {
        public OrganizationEfRepository(ApplicationDbContext dbContext) : base(dbContext, true)
        {

        }
    }
}
