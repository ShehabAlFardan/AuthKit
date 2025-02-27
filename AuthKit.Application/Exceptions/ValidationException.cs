using AuthKit.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Application.Exceptions
{
    public class ValidationException : Exception
    {
        private readonly List<ValidationError> _errors;

        public List<ValidationError> Errors => _errors;

        public ValidationException(List<ValidationError> errors)
        {
            _errors = errors;
        }
    }
}
