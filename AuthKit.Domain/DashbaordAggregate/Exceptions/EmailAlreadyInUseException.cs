using AuthKit.Domain.Exceptions;

namespace AuthKit.Domain.DashbaordAggregate.Exceptions
{
    public class EmailAlreadyInUseException : DomainException
    {
        public EmailAlreadyInUseException()
            : base(
                "Email Already In Use",
                "The provided email address is already associated with another account. Please use a different email address.",
                DashboardUserErrorCodes.EmailAlreadyInUse.ToString("D"))
        {

        }
    }

}
