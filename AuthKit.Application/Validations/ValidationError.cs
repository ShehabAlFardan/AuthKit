using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Application.Validations
{
    public class ValidationError
    {
        public string? Code { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
    }
}
