using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public CustomException() : base() { }

        public CustomException(string message) : base(message) { }

        public CustomException(int statusCode, string message) : base(message) {
            StatusCode = statusCode;
        }
    }
}
