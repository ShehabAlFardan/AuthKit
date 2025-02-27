using AuthKit.Domain.DashbaordAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Application.DashboardAggregate.Queries
{
    public interface IDashboardUserQueries
    {
        public Task<DashboardUser?> GetDashboardUserByEmail(string email);

    }
}
