using AuthKit.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Domain.DashbaordAggregate.Exceptions
{
    public class InvalidEmailOrPasswordException : DomainException
    {
        public InvalidEmailOrPasswordException()
            : base(
                "Invalid Email or Password",
                "The email or password provided is incorrect. Please check your credentials and try again.",
                DashboardUserErrorCodes.InvalidEmailOrPassword.ToString("D"))
        {
        }
    }
}
