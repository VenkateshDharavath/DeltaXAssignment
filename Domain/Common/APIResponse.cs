using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class APIResponse
    {
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public int StatusCode { get; set; }
        [DataMember] // (EmitDefaultValue = false)
        public object? Result { get; set; }
        [DataMember]
        public List<string> Errors;
        [DataMember]
        public string Message;

        public APIResponse() { }

        public APIResponse(string version, int status, object? result, List<string> errors, string message)
        {
            Version = version;
            StatusCode = status;
            Result = result;
            Errors = errors;
            Message = message;
        }
    }
}
